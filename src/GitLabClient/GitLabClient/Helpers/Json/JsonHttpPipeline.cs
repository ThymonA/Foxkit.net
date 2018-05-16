namespace GitLabClient
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net.Http;

    public class JsonHttpPipeline : IJsonHttpPipeline
    {
        private readonly IJsonSerializer serializer;

        public JsonHttpPipeline()
            : this(new SimpleJsonSerializer())
        {
        }

        public JsonHttpPipeline(IJsonSerializer serializer)
        {
            serializer.ArgumentNotNull(nameof(serializer));

            this.serializer = serializer;
        }

        public void SerializeRequest(IRequest request)
        {
            request.ArgumentNotNull(nameof(request));

            if (!request.Headers.ContainsKey("Accept"))
            {
                request.Headers["Accept"] = AcceptHeaders.RedirectsPreviewThenStableVersionJson;
            }

            if (request.Method == HttpMethod.Get || request.Body == null)
            {
                return;
            }

            if (request.Body is string || request.Body is Stream || request.Body is HttpContent)
            {
                return;
            }

            request.Body = serializer.Serialize(request.Body);
        }

        public IApiResponse<T> DeserializeResponse<T>(IResponse response)
            where T : class
        {
            response.ArgumentNotNull(nameof(response));

            if (response.ContentType != null && response.ContentType.Equals("application/json", StringComparison.Ordinal))
            {
                var body = response.Body as string;

                if (!string.IsNullOrEmpty(body) && body != "{}")
                {
                    var typeIsDictionary = typeof(IDictionary).IsAssignableFrom(typeof(T));
                    var typeIsEnumerable = typeof(IEnumerable).IsAssignableFrom(typeof(T));
                    var responseIsObject = body != null && body.StartsWith("{", StringComparison.Ordinal);

                    if (!typeIsDictionary && typeIsEnumerable && responseIsObject)
                    {
                        body = "[" + body + "]";
                    }

                    var json = serializer.Deserialize<T>(body);

                    return new ApiResponse<T>(response, json);
                }
            }

            return new ApiResponse<T>(response);
        }
    }
}
