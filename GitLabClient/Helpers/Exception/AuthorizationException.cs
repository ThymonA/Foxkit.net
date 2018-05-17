namespace Foxkit
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class AuthorizationException : ApiException
    {
        public AuthorizationException()
            : base(HttpStatusCode.Unauthorized, null)
        {
        }

        public AuthorizationException(IResponse response)
            : this(response, null)
        {
        }

        public AuthorizationException(string message, HttpStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public AuthorizationException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Unauthorized, "AuthorizationException wrong status code");
        }

        public AuthorizationException(HttpStatusCode httpStatusCode, Exception innerException)
            : base(httpStatusCode, innerException)
        {
        }
    }
}
