namespace GitLabClient
{
    using System;

    public class RateLimitExceededException : ForbiddenException
    {
        private readonly IRateLimit rateLimit;

        public RateLimitExceededException(IResponse response) : this(response, null)
        {
        }

        public RateLimitExceededException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            response.ArgumentNotNull(nameof(response));

            rateLimit = response.ApiInfo.RateLimit;
        }

        public int Limit => rateLimit.Limit;

        public int Remaining => rateLimit.Remaining;

        public DateTimeOffset Reset => rateLimit.Reset;

        public override string Message => ApiErrorMessageSafe ?? "API Rate Limit exceeded";
    }
}
