namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public class Request : IRequest
    {
        public Request()
        {
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
            Timeout = TimeSpan.FromSeconds(100);
        }

        public object Body { get; set; }

        public IDictionary<string, string> Headers { get; }

        public HttpMethod Method { get; set; }

        public IDictionary<string, string> Parameters { get; }

        public Uri BaseAddress { get; set; }

        public Uri Endpoint { get; set; }

        public TimeSpan Timeout { get; set; }

        public string ContentType { get; set; }
    }
}
