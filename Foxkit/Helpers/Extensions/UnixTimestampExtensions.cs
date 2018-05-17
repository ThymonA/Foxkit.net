namespace Foxkit
{
    using System;

    public static class UnixTimestampExtensions
    {
        public static DateTimeOffset Epoch => new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        /// Convert a Unix tick to a <see cref="DateTimeOffset"/> with UTC offset
        /// </summary>
        /// <param name="unixTime">UTC tick</param>
        /// <returns>A <see cref="DateTimeOffset"/></returns>
        public static DateTimeOffset FromUnixTime(this long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Convert <see cref="DateTimeOffset"/> with UTC offset to a Unix tick
        /// </summary>
        /// <param name="date">Date Time with UTC offset</param>
        /// <returns>Unix timestamp</returns>
        public static long ToUnixTime(this DateTimeOffset date)
        {
            return Convert.ToInt64((date.ToUniversalTime() - Epoch).TotalSeconds);
        }
    }
}
