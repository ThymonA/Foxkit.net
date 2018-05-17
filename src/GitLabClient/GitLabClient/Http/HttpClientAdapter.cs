namespace GitLabClient
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class HttpClientAdapter : IHttpClient
    {
        private const string RedirectCountKey = "RedirectCount";

        private readonly HttpClient http;

        public HttpClientAdapter(Func<HttpMessageHandler> getHandler)
        {
            getHandler.ArgumentNotNull(nameof(getHandler));

            http = new HttpClient(new RedirectHandler { InnerHandler = getHandler() });
        }

        public async Task<IResponse> Send(IRequest request, CancellationToken cancellationToken)
        {
            request.ArgumentNotNull(nameof(request));

            var cancellationTokenForRequest = GetCancellationTokenForRequest(request, cancellationToken);

            using (var requestMessage = BuildRequestMessage(request))
            {
                var responseMessage = await SendAsync(requestMessage, cancellationTokenForRequest).ConfigureAwait(false);

                return await BuildResponse(responseMessage).ConfigureAwait(false);
            }
        }

        public void SetRequestTimeout(TimeSpan timeout)
        {
            http.Timeout = timeout;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static CancellationToken GetCancellationTokenForRequest(IRequest request, CancellationToken cancellationToken)
        {
            var cancellationTokenForRequest = cancellationToken;

            if (request.Timeout != TimeSpan.Zero)
            {
                var timeoutCancellation = new CancellationTokenSource(request.Timeout);
                var unifiedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellation.Token);

                cancellationTokenForRequest = unifiedCancellationToken.Token;
            }

            return cancellationTokenForRequest;
        }

        private static string GetContentType(HttpContent httpContent)
        {
            if (!httpContent.Headers.IsNullOrDefault() && !httpContent.Headers.ContentType.IsNullOrDefault())
            {
                return httpContent.Headers.ContentType.MediaType;
            }

            return string.Empty;
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var cloneRequest = await CloneHttpRequestMessage(request).ConfigureAwait(false);

            var response = await http.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);

            if (response.Headers.Location == null)
            {
                return response;
            }

            var redirectCount = 0;

            if (request.Properties.Keys.Contains(RedirectCountKey))
            {
                redirectCount = (int)request.Properties[RedirectCountKey];
            }

            if (redirectCount > 3)
            {
                throw new InvalidOperationException("The redirect count for this request has been exceeded");
            }

            if (response.StatusCode == HttpStatusCode.MovedPermanently || response.StatusCode == HttpStatusCode.Redirect || response.StatusCode == HttpStatusCode.Found
                || response.StatusCode == HttpStatusCode.SeeOther || response.StatusCode == HttpStatusCode.TemporaryRedirect || (int)response.StatusCode == 308)
            {
                if (response.StatusCode == HttpStatusCode.SeeOther)
                {
                    cloneRequest.Content = null;
                    cloneRequest.Method = HttpMethod.Get;
                }

                cloneRequest.Properties[RedirectCountKey] = ++redirectCount;
                cloneRequest.RequestUri = response.Headers.Location;

                if (string.Compare(cloneRequest.RequestUri.Host, request.RequestUri.Host, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    cloneRequest.Headers.Authorization = null;
                }

                response = await SendAsync(cloneRequest, cancellationToken).ConfigureAwait(false);
            }

            return response;
        }

        private async Task<HttpRequestMessage> CloneHttpRequestMessage(HttpRequestMessage oldRequest)
        {
            var request = new HttpRequestMessage(oldRequest.Method, oldRequest.RequestUri);

            using (var ms = new MemoryStream())
            {
                if (oldRequest.Content != null)
                {
                    await oldRequest.Content.CopyToAsync(ms).ConfigureAwait(false);

                    ms.Position = 0;
                    request.Content = new StreamContent(ms);

                    if (oldRequest.Content.Headers != null)
                    {
                        foreach (var header in oldRequest.Content.Headers)
                        {
                            request.Content.Headers.Add(header.Key, header.Value);
                        }
                    }
                }
            }

            request.Version = oldRequest.Version;

            foreach (var header in oldRequest.Headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            foreach (var property in oldRequest.Properties)
            {
                request.Properties.Add(property);
            }

            return request;
        }

        private HttpRequestMessage BuildRequestMessage(IRequest request)
        {
            request.ArgumentNotNull(nameof(request));

            var fullUri = new Uri(request.BaseAddress, request.Endpoint);
            var requestMessage = new HttpRequestMessage(request.Method, fullUri);

            try
            {
                foreach (var header in request.Headers)
                {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }

                switch (request.Body)
                {
                    case HttpContent httpContent:
                        requestMessage.Content = httpContent;
                        break;
                    case string body:
                        requestMessage.Content = new StringContent(body, Encoding.UTF8, request.ContentType);
                        break;
                    case Stream bodyStream:
                        requestMessage.Content = new StreamContent(bodyStream);
                        requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(request.ContentType);
                        break;
                }
            }
            catch (Exception)
            {
                if (!requestMessage.IsNullOrDefault())
                {
                    requestMessage.Dispose();
                }

                throw;
            }

            return requestMessage;
        }

        private async Task<IResponse> BuildResponse(HttpResponseMessage responseMessage)
        {
            responseMessage.ArgumentNotNull(nameof(responseMessage));

            object responseBody = null;
            var contentType = string.Empty;

            var binaryContentTypes = new[] { "application/zip", "application/x-gzip", "application/octet-stream" };

            using (var content = responseMessage.Content)
            {
                if (!content.IsNullOrDefault())
                {
                    contentType = GetContentType(responseMessage.Content);

                    if (!string.IsNullOrEmpty(contentType) && (contentType.StartsWith("image/") || binaryContentTypes.Any(item => item.Equals(contentType, StringComparison.OrdinalIgnoreCase))))
                    {
                        responseBody = await responseMessage.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        responseBody = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }
                }
            }

            return new Response(responseMessage.StatusCode, responseBody, responseMessage.Headers.ToDictionary(x => x.Key, x => x.Value.First()), contentType);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !http.IsNullOrDefault())
            {
                http.Dispose();
            }
        }
    }
}
