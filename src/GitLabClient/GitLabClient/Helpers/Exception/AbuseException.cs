namespace Foxkit
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class AbuseException : ForbiddenException
    {
        public AbuseException(IResponse response)
            : this(response, null)
        {
        }

        public AbuseException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.Forbidden, "AbuseException created with wrong status code");

            RetryAfterSeconds = ParseRetryAfterSeconds(response);
        }

        private static int? ParseRetryAfterSeconds(IResponse response)
        {
            if (!response.Headers.TryGetValue("Retry-After", out var secondsValue))
            {
                return null;
            }

            if (!int.TryParse(secondsValue, out var retrySeconds))
            {
                return null;
            }

            if (retrySeconds < 0)
            {
                return null;
            }

            return retrySeconds;
        }

        public int? RetryAfterSeconds { get;  }

        public override string Message => ApiErrorMessageSafe ?? "Request Forbidden - Abuse Detection";
    }
}
