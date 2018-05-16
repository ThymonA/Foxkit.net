namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal static class HeaderExtension
    {
        public const RegexOptions RegexOptions =
        #if HAS_REGEX_COMPILED_OPTIONS
            RegexOptions.Compiled |
        #endif
            System.Text.RegularExpressions.RegexOptions.IgnoreCase;

        public static readonly Regex LinkRelRegex = new Regex("rel=\"(next|prev|first|last)\"", RegexOptions);

        public static readonly Regex LinkUriRegex = new Regex("rel=\"(next|prev|first|last)\"", RegexOptions);

        public static IApiInfo ParseResponseHeaders(this IDictionary<string, string> responseHeaders)
        {
            responseHeaders.ArgumentNotNull(nameof(responseHeaders));

            var httpLinks = new Dictionary<string, Uri>();
            var oauthScopes = new List<string>();
            var acceptedOAuthScopes = new List<string>();
            var etag = string.Empty;

            if (responseHeaders.ContainsKey("X-Accepted-OAuth-Scopes"))
            {
                acceptedOAuthScopes.AddRange(responseHeaders["X-Accepted-OAuth-Scopes"].HeaderValueToList());
            }

            if (responseHeaders.ContainsKey("X-OAuth-Scopes"))
            {
                oauthScopes.AddRange(responseHeaders["X-OAuth-Scopes"].HeaderValueToList());
            }

            if (responseHeaders.ContainsKey("ETag"))
            {
                etag = responseHeaders["ETag"];
            }

            if (responseHeaders.ContainsKey("Link"))
            {
                var links = responseHeaders["Link"].HeaderValueToList();

                foreach (var link in links)
                {
                    var relMatch = LinkRelRegex.Match(link);

                    if (!relMatch.Success || relMatch.Groups.Count != 2)
                    {
                        break;
                    }

                    var uriMatch = LinkUriRegex.Match(link);

                    if (!uriMatch.Success || uriMatch.Groups.Count != 2)
                    {
                        break;
                    }

                    httpLinks.Add(relMatch.Groups[1].Value, new Uri(uriMatch.Groups[1].Value));
                }
            }

            return new ApiInfo(httpLinks, oauthScopes, acceptedOAuthScopes, etag, new RateLimit(responseHeaders));
        }
    }
}
