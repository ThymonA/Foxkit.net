namespace GitLabClient
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public abstract class TwoFactorAuthorizationException : AuthorizationException
    {
        protected TwoFactorAuthorizationException(TwoFactorType twoFactorType, Exception innerException)
            : base(HttpStatusCode.Unauthorized, innerException)
        {
            TwoFactorType = twoFactorType;
        }

        protected TwoFactorAuthorizationException(IResponse response, TwoFactorType twoFactorType)
            : base(response)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Unauthorized, "TwoFactorRequiredException status code should be 401");

            TwoFactorType = twoFactorType;
        }

        protected TwoFactorAuthorizationException(IResponse response, TwoFactorType twoFactorType, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Unauthorized, "TwoFactorRequiredException status code should be 401");

            TwoFactorType = twoFactorType;
        }

        protected TwoFactorAuthorizationException(string message, HttpStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        protected TwoFactorAuthorizationException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
        }

        public TwoFactorType TwoFactorType { get; }
    }
}
