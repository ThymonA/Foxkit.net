namespace Foxkit
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class ForbiddenException : ApiException
    {
        public ForbiddenException(IResponse response)
            : this(response, null)
        {
        }

        public ForbiddenException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Forbidden, "ForbiddenException created with wrong status code");
        }

        public override string Message => ApiErrorMessageSafe ?? "Request Forbidden";
    }
}
