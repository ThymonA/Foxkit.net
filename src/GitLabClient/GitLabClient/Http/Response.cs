namespace GitLabClient
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;

    internal class Response : IResponse
    {
        public Response()
            : this(new Dictionary<string, string>())
        {
        }

        public Response(IDictionary<string, string> headers)
        {
            headers.ArgumentNotNull(nameof(headers));

            Headers = new ReadOnlyDictionary<string, string>(headers);
            ApiInfo = headers.ParseResponseHeaders();
        }

        public Response(
            HttpStatusCode statusCode,
            object body,
            IDictionary<string, string> headers,
            string contentType)
        {
            StatusCode = statusCode;
            Body = body;
            Headers = new ReadOnlyDictionary<string, string>(headers);
            ApiInfo = headers.ParseResponseHeaders();
            ContentType = contentType;
        }

        public object Body { get; }

        public IReadOnlyDictionary<string, string> Headers { get; }

        public IApiInfo ApiInfo { get; }

        public HttpStatusCode StatusCode { get; }

        public string ContentType { get; }
    }
}
