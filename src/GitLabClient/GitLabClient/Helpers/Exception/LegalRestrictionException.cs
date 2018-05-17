namespace Foxkit
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class LegalRestrictionException : ApiException
    {
        public LegalRestrictionException(IResponse response)
            : this(response, null)
        {
        }

        public LegalRestrictionException(string message, HttpStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public LegalRestrictionException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == (HttpStatusCode)451, "LegalRestrictionException created with wrong status code");
        }

        public override string Message => ApiErrorMessageSafe ?? "Resource taken down due to a DMCA notice.";
    }
}
