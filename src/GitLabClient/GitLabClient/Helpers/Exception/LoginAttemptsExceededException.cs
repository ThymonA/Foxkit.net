namespace Foxkit
{
    using System;

    public class LoginAttemptsExceededException : ForbiddenException
    {
        public LoginAttemptsExceededException(IResponse response)
            : base(response)
        {
        }

        public LoginAttemptsExceededException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
        }

        public override string Message => ApiErrorMessageSafe ?? "Maximum number of login attempts exceeded";
    }
}
