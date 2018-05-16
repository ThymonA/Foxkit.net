namespace GitLabClient
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class TwoFactorRequiredException : TwoFactorAuthorizationException
    {
        public TwoFactorRequiredException()
            : this(TwoFactorType.None)
        {
        }

        public TwoFactorRequiredException(TwoFactorType twoFactorType)
            : base(twoFactorType, null)
        {
        }

        public TwoFactorRequiredException(IResponse response, TwoFactorType twoFactorType)
            : base(response, twoFactorType)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Unauthorized, "TwoFactorRequiredException wrong status code");
        }

        public override string Message => ApiErrorMessageSafe ?? "Two-factor authentication code is required";
    }
}
