namespace GitLabClient
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class ApiValidationException : ApiException
    {
        public ApiValidationException()
            : base((HttpStatusCode)422, null)
        {
        }

        public ApiValidationException(IResponse response)
            : this(response, null)
        {
        }

        public ApiValidationException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == (HttpStatusCode)422, "ApiValidationException created with wrong status code");
        }

        protected ApiValidationException(ApiException innerException)
            : base(innerException)
        {
        }

        public override string Message => ApiErrorMessageSafe ?? "Validation Failed";
    }
}
