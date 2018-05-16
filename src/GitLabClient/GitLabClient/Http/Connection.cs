namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class Connection : IConnection
    {
        public static readonly Uri DefaultGitLabUri = GitLabClient.GitLabUri;
        private static readonly ICredentialStore AnonymousCredentials = new InMemoryCredentialStore(global::GitLabClient.Credentials.Anonymous);

        private readonly IAuthenticator authenticator;
        private readonly IHttpClient httpClient;
        private readonly IJsonHttpPipeline jsonPipeline;

        public Connection(IProductHeaderValue productInformation)
            : this(productInformation, DefaultGitLabUri, AnonymousCredentials)
        {
        }

        public Connection(IProductHeaderValue productInformation, IHttpClient httpClient)
            : this(productInformation, DefaultGitLabUri, AnonymousCredentials, httpClient, new SimpleJsonSerializer())
        {
        }

        public Connection(IProductHeaderValue productInformation, Uri baseAddress)
            : this(productInformation, baseAddress, AnonymousCredentials)
        {
        }

        public Connection(IProductHeaderValue productInformation, ICredentialStore credentialStore)
            : this(productInformation, DefaultGitLabUri, credentialStore)
        {
        }

        public Connection(IProductHeaderValue productInformation, Uri baseAddress, ICredentialStore credentialStore)
            : this(productInformation, baseAddress, credentialStore, new HttpClientAdapter(HttpMessageHandlerFactory.CreateDefault), new SimpleJsonSerializer())
        {
        }

        public Connection(
            IProductHeaderValue productInformation,
            Uri baseAddress,
            ICredentialStore credentialStore,
            IHttpClient httpClient,
            IJsonSerializer serializer)
        {
            productInformation.ArgumentNotNull(nameof(productInformation));
            baseAddress.ArgumentNotNull(nameof(baseAddress));
            credentialStore.ArgumentNotNull(nameof(credentialStore));
            httpClient.ArgumentNotNull(nameof(httpClient));
            serializer.ArgumentNotNull(nameof(serializer));

            if (!baseAddress.IsAbsoluteUri)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The base address '{0}' must be an absolute URI", baseAddress), nameof(baseAddress));
            }

            UserAgent = FormatUserAgent(productInformation);
            BaseAddress = baseAddress;

            authenticator = new Authenticator(credentialStore);
            this.httpClient = httpClient;
            jsonPipeline = new JsonHttpPipeline(serializer);
        }

        public Task<IApiResponse<string>> GetHtml(Uri uri, IDictionary<string, string> parameters)
        {
            uri.ArgumentNotNull(nameof(uri));

            var request = new Request
            {
                Method = HttpMethod.Get,
                BaseAddress = BaseAddress,
                Endpoint = uri.ApplyParameters(parameters)
            };

            return GetHtml(request);
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, TimeSpan timeout)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            return SendData<T>(uri, HttpMethod.Get, null, null, null, timeout, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            return SendData<T>(uri.ApplyParameters(parameters), HttpMethod.Get, null, accepts, null, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts, CancellationToken cancellationToken)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            return SendData<T>(uri.ApplyParameters(parameters), HttpMethod.Get, null, accepts, null, cancellationToken);
        }

        public async Task<HttpStatusCode> Patch(Uri uri)
        {
            uri.ArgumentNotNull(nameof(uri));

            var request = new Request
            {
                Method = HttpVerb.Patch,
                BaseAddress = BaseAddress,
                Endpoint = uri
            };

            var response = await Run<object>(request, CancellationToken.None).ConfigureAwait(false);

            return response.HttpResponse.StatusCode;
        }

        public async Task<HttpStatusCode> Patch(Uri uri, string accepts)
        {
            uri.ArgumentNotNull(nameof(uri));
            accepts.ArgumentNotNull(nameof(accepts));

            var response = 
        }

        public Task<IApiResponse<T>> Patch<T>(Uri uri, object body)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));

            return SendData<T>(uri, HttpVerb.Patch, body, null, null, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Patch<T>(Uri uri, object body, string accepts)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));
            accepts.ArgumentNotNull(nameof(accepts));

            return SendData<T>(uri, HttpVerb.Patch, body, accepts, null, CancellationToken.None);
        }

        public Task<HttpStatusCode> Post(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, string twoFactorAuthenticationCode)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, TimeSpan timeout)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, Uri baseAddress)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Put(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Put<T>(Uri uri, object body)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode, string accepts)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri, string twoFactoryAuthenticationCode)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri, object data)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri, object data, string accepts)
        {
            throw new NotImplementedException();
        }

        public Uri BaseAddress { get; }

        public string UserAgent { get; }

        public ICredentialStore CredentialStore { get; }

        public ICredentials Credentials { get; set; }

        public void SetRequestTimeout(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public static string FormatUserAgent(IProductHeaderValue productInformation)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0} ({1}; {2}; Octokit {3})",
                productInformation,
                GetPlatformInformation(),
                GetCultureInformation(),
                GetVersionInformation());
        }

        private static string platformInformation;

        public static string GetPlatformInformation()
        {
            if (string.IsNullOrEmpty(platformInformation))
            {
                try
                {
                    platformInformation = string.Format(CultureInfo.InvariantCulture,
                    #if !HAS_ENVIRONMENT
                    "{0}; {1}",
                    RuntimeInformation.OSDescription.Trim(),
                    RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant().Trim()
                    #else
                    "{0} {1}; {2}",
                    Environment.OSVersion.Platform,
                    Environment.OSVersion.Version.ToString(3),
                    Environment.Is64BitOperatingSystem ? "amd64" : "x86"
                    #endif
                    );
                }
                catch
                {
                    platformInformation = "Unknown Platform";
                }
            }

            return platformInformation;
        }

        static string GetCultureInformation()
        {
            return CultureInfo.CurrentCulture.Name;
        }

        private static string versionInformation;

        public static string GetVersionInformation()
        {
            if (string.IsNullOrEmpty(versionInformation))
            {
                versionInformation = typeof(IGitLabClient)
                    .GetTypeInfo()
                    .Assembly
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    .InformationalVersion;
            }

            return versionInformation;
        }

        private static IApiInfo latestApiInfo;

        public static IApiInfo GetLatestApiInfo()
        {
            return latestApiInfo?.Clone();
        }

        private static readonly Dictionary<HttpStatusCode, Func<IResponse, Exception>> httpExceptionMap =
            new Dictionary<HttpStatusCode, Func<IResponse, Exception>>
            {
                { HttpStatusCode.Unauthorized, GetExceptionForUnauthorized },
                { HttpStatusCode.Forbidden, GetExceptionForForbidden },
                { HttpStatusCode.NotFound, response => new NotFoundException(response) },
                { (HttpStatusCode)422, response => new ApiValidationException(response) },
                { (HttpStatusCode)451, response => new LegalRestrictionException(response) }
            };

        private static Exception GetExceptionForUnauthorized(IResponse response)
        {
            var twoFactorType = ParseTwoFactorType(response);

            return twoFactorType == TwoFactorType.None
                ? new AuthorizationException(response)
                : new TwoFactorRequiredException(response, twoFactorType);
        }

        private static Exception GetExceptionForForbidden(IResponse response)
        {
            var body = response.Body as string ?? "";

            if (body.Contains("rate limit exceeded"))
            {
                return new RateLimitExceededException(response);
            }

            if (body.Contains("number of login attempts exceeded"))
            {
                return new LoginAttemptsExceededException(response);
            }

            if (body.Contains("abuse-rate-limits") || body.Contains("abuse detection mechanism"))
            {
                return new AbuseException(response);
            }

            return new ForbiddenException(response);
        }

        private async Task<IApiResponse<string>> GetHtml(IRequest request)
        {
            request.Headers.Add("Accept", AcceptHeaders.StableVersionHtml);

            var response = await RunRequest(request, CancellationToken.None).ConfigureAwait(false);

            return new ApiResponse<string>(response, response.Body as string);
        }

        private Task<IApiResponse<T>> SendData<T>(
            Uri uri,
            HttpMethod method,
            object body,
            string accepts,
            string contentType,
            TimeSpan timeout,
            CancellationToken cancellationToken,
            string twoFactorAuthenticationCode = null,
            Uri baseAddress = null)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            timeout.ArgumentNotNull(nameof(timeout));

            var request = new Request
            {
                Method = method,
                BaseAddress = baseAddress ?? BaseAddress,
                Endpoint = uri,
                Timeout = timeout
            };

            return SendDataInternal<T>(body, accepts, contentType, cancellationToken, twoFactorAuthenticationCode, request);
        }

        private Task<IApiResponse<T>> SendData<T>(
            Uri uri,
            HttpMethod method,
            object body,
            string accepts,
            string contentType,
            CancellationToken cancellationToken,
            string twoFactorAuthenticationCode = null,
            Uri baseAddress = null)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            var request = new Request
            {
                Method = method,
                BaseAddress = baseAddress ?? BaseAddress,
                Endpoint = uri
            };

            return SendDataInternal<T>(body, accepts, contentType, cancellationToken, twoFactorAuthenticationCode, request);
        }

        private Task<IApiResponse<T>> SendDataInternal<T>(
            object body,
            string accepts,
            string contentType,
            CancellationToken cancellationToken,
            string twoFactorAuthenticationCode,
            IRequest request)
            where T : class
        {
            if (!string.IsNullOrEmpty(accepts))
            {
                request.Headers["Accept"] = accepts;
            }

            if (!string.IsNullOrEmpty(twoFactorAuthenticationCode))
            {
                request.Headers["X-GitHub-OTP"] = twoFactorAuthenticationCode;
            }

            if (body != null)
            {
                request.Body = body;
                request.ContentType = contentType ?? "application/x-www-form-urlencoded";
            }

            return Run<T>(request, cancellationToken);
        }

        private async Task<IApiResponse<T>> Run<T>(IRequest request, CancellationToken cancellationToken)
            where T : class
        {
            jsonPipeline.SerializeRequest(request);

            var response = await RunRequest(request, cancellationToken).ConfigureAwait(false);

            return jsonPipeline.DeserializeResponse<T>(response);
        }

        private async Task<IResponse> RunRequest(IRequest request, CancellationToken cancellationToken)
        {
            request.Headers.Add("User-Agent", UserAgent);
            await authenticator.Apply(request).ConfigureAwait(false);
            var response = await httpClient.Send(request, cancellationToken).ConfigureAwait(false);
            if (response != null)
            {
                latestApiInfo = response.ApiInfo.Clone();
            }

            HandleErrors(response);

            return response;
        }

        private void HandleErrors(IResponse response)
        {
            Func<IResponse, Exception> exceptionFunc;
            if (httpExceptionMap.TryGetValue(response.StatusCode, out exceptionFunc))
            {
                throw exceptionFunc(response);
            }

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(response);
            }
        }

        internal static TwoFactorType ParseTwoFactorType(IResponse restResponse)
        {
            if (restResponse?.Headers == null || !restResponse.Headers.Any())
            {
                return TwoFactorType.None;
            }

            var otpHeader = restResponse.Headers.FirstOrDefault(header =>
                header.Key.Equals("X-GitHub-OTP", StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(otpHeader.Value))
            {
                return TwoFactorType.None;
            }

            var factorType = otpHeader.Value;
            var parts = factorType.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0 && parts[0] == "required")
            {
                var secondPart = parts.Length > 1 ? parts[1].Trim() : null;

                switch (secondPart)
                {
                    case "sms":
                        return TwoFactorType.Sms;
                    case "app":
                        return TwoFactorType.AuthenticatorApp;
                    default:
                        return TwoFactorType.Unknown;
                }
            }

            return TwoFactorType.None;
        }
    }
}
