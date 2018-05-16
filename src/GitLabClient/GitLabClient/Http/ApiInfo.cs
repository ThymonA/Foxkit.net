namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Extra information returned as part of each api response.
    /// </summary>
    public class ApiInfo : IApiInfo
    {
        public ApiInfo(
            IDictionary<string, Uri> links,
            IList<string> oauthScopes,
            IList<string> acceptedOauthScopes,
            string etag,
            IRateLimit rateLimit)
        {
            links.ArgumentNotNull(nameof(links));
            oauthScopes.ArgumentNotNull(nameof(oauthScopes));
            acceptedOauthScopes.ArgumentNotNull(nameof(acceptedOauthScopes));

            Links = new ReadOnlyDictionary<string, Uri>(links);
            OauthScopes = new ReadOnlyCollection<string>(oauthScopes);
            AcceptedOauthScopes = new ReadOnlyCollection<string>(acceptedOauthScopes);
            Etag = etag;
            RateLimit = rateLimit;
        }

        public IReadOnlyList<string> OauthScopes { get; }

        public IReadOnlyList<string> AcceptedOauthScopes { get; }

        public string Etag { get; }

        public IReadOnlyDictionary<string, Uri> Links { get; }

        public IRateLimit RateLimit { get; }

        public IApiInfo Clone()
        {
            return new ApiInfo(
                Links.Clone(),
                OauthScopes.Clone(),
                AcceptedOauthScopes.Clone(),
                Etag != null ? new string(Etag.ToCharArray()) : null,
                RateLimit?.Clone());
        }
    }
}
