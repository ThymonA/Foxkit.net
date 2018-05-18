namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class RateLimit : IRateLimit
    {
        public RateLimit()
        {
        }

        public RateLimit(IDictionary<string, string> responseHeaders)
        {
            responseHeaders.ArgumentNotNull(nameof(responseHeaders));

            Limit = (int)GetHeaderValueAsInt32Safe(responseHeaders, "X-RateLimit-Limit");
            Remaining = (int)GetHeaderValueAsInt32Safe(responseHeaders, "X-RateLimit-Remaining");
            ResetAsUtcEpochSeconds = GetHeaderValueAsInt32Safe(responseHeaders, "X-RateLimit-Reset");
        }

        public int Limit { get; private set; }

        public int Remaining { get; private set; }

        public DateTimeOffset Reset => ResetAsUtcEpochSeconds.FromUnixTime();

        public long ResetAsUtcEpochSeconds { get; private set; }

        public IRateLimit Clone()
        {
            return new RateLimit
            {
                Limit = Limit,
                Remaining = Remaining,
                ResetAsUtcEpochSeconds = ResetAsUtcEpochSeconds
            };
        }

        internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Limit {0}, Remaining {1}, Reset {2} ", Limit, Remaining, Reset);

        public long GetHeaderValueAsInt32Safe(IDictionary<string, string> responseHeaders, string key)
        {
            return !responseHeaders.TryGetValue(key, out var value) || value == null || !long.TryParse(value, out var result)
                ? 0
                : result;
        }
    }
}
