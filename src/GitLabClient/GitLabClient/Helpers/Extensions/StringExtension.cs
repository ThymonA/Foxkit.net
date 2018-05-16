namespace GitLabClient
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public static class StringExtension
    {
        public static void ArgumentNotNullOrEmptyString(this string argument, string argumentName)
        {
            var str = argument.RemoveMultipleSpaces();

            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static string RemoveMultipleSpaces(this string input)
        {
            return Regex.Replace(input.Trim(), @"\s+", " ");
        }

        public static Uri FormatUri(this string pattern, params object[] args)
        {
            pattern.ArgumentNotNullOrEmptyString(nameof(pattern));

            return new Uri(string.Format(CultureInfo.InvariantCulture, pattern, args), UriKind.Relative);
        }
    }
}
