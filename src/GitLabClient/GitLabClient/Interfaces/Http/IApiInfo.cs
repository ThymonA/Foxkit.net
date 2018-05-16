namespace GitLabClient.Interfaces.Http
{
    using System;
    using System.Collections.Generic;

    public interface IApiInfo
    {
        /// <summary>
        /// Oauth scopes that were included in the token used to make the request.
        /// </summary>
        IReadOnlyList<string> OauthScopes { get; }

        /// <summary>
        /// Oauth scopes accepted for this particular call.
        /// </summary>
        IReadOnlyList<string> AcceptedOauthScopes { get; }

        /// <summary>
        /// Etag
        /// </summary>
        string Etag { get; }

        /// <summary>
        /// Links to things like next/previous pages
        /// </summary>
        IReadOnlyDictionary<string, Uri> Links { get; }
    }
}
