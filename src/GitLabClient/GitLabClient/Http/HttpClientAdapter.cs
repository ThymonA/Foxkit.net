using System;
using System.Net.Http;

namespace GitLabClient
{
    public class HttpClientAdapter : IHttpClient
    {
        private Func<HttpMessageHandler> createDefault;

        public HttpClientAdapter(Func<HttpMessageHandler> createDefault)
        {
            this.createDefault = createDefault;
        }
    }
}
