namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
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

        public static List<string> HeaderValueToList(this string header)
        {
            return header.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
        }

        public static string UrlEncode(this string input)
        {
            var chars = input.ToCharArray();
            var encodedValue = new StringBuilder();

            foreach (var c in chars)
            {
                encodedValue.Append("%" + ((int)c).ToString("X2"));
            }

            return encodedValue.ToString();
        }
    }
}
