namespace GitLabClient
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorizationsClient
    {
        /// <summary>
        /// Gets all <see cref="Authorization"/>s for the authenticated user
        /// </summary>
        /// <returns>A list of <see cref="Authorization"/>s for the authenticated user.</returns>
        Task<IReadOnlyList<Authorization>> GetAll();

        /// <summary>
        /// Gets all <see cref="Authorization"/>s for the authenticated user
        /// </summary>
        /// <param name="options">Options for changing the API response</param>
        /// <returns>A list of <see cref="Authorization"/>s for the authenticated user.</returns>
        Task<IReadOnlyList<Authorization>> GetAll(IApiOptions options);

        /// <summary>
        /// Gets a specific <see cref="Authorization"/> for the authenticated user
        /// </summary>
        /// <param name="id">The Id of the <see cref="Authorization"/> to get</param>
        /// <returns>The specified <see cref="Authorization"/></returns>
        Task<Authorization> Get(long id);

        /// <summary>
        /// Creates a new personal token for the authenticated user
        /// </summary>
        /// <param name="newAuthorization">Describes the new authorization to create</param>
        /// <returns>The created <see cref="Authorization"/></returns>
        Task<ApplicationAuthorization> Create(NewAuthorization newAuthorization);

        /// <summary>
        /// Creates a new personal token for the authenticated user
        /// </summary>
        /// <param name="newAuthorization">Describes the new authorization to create</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns>The created <see cref="Authorization"/></returns>
        Task<ApplicationAuthorization> Create(NewAuthorization newAuthorization, string twoFactorAuthenticationCode);

        /// <summary>
        /// Creates a new personal token for the authenticated user
        /// </summary>
        /// <param name="clientId">Client Id of the OAuth application for the token</param>
        /// <param name="clientSecret">The client secret</param>
        /// <param name="newAuthorization">Describes the new authorization to create</param>
        /// <returns>The created <see cref="Authorization"/></returns>
        Task<ApplicationAuthorization> Create(
            string clientId,
            string clientSecret,
            NewAuthorization newAuthorization);

        /// <summary>
        /// Creates a new personal token for the authenticated user
        /// </summary>
        /// <param name="clientId">Client Id of the OAuth application for the token</param>
        /// <param name="clientSecret">The client secret</param>
        /// <param name="newAuthorization">Describes the new authorization to create</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns>The created <see cref="Authorization"/></returns>
        Task<ApplicationAuthorization> Create(
            string clientId,
            string clientSecret,
            NewAuthorization newAuthorization,
            string twoFactorAuthenticationCode);

        /// <summary>
        /// Creates a new personal token if not exists for the authenticated user
        /// </summary>
        /// <param name="clientId">Client Id of the OAuth application for the token</param>
        /// <param name="clientSecret">The client secret</param>
        /// <param name="newAuthorization">Describes the new authorization to create</param>
        /// <returns>The created <see cref="Authorization"/></returns>
        Task<ApplicationAuthorization> GetOrCreateApplicationAuthorization(
            string clientId,
            string clientSecret,
            NewAuthorization newAuthorization);

        /// <summary>
        /// Creates a new personal token if not exists for the authenticated user
        /// </summary>
        /// <param name="clientId">Client Id of the OAuth application for the token</param>
        /// <param name="clientSecret">The client secret</param>
        /// <param name="newAuthorization">Describes the new authorization to create</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns>The created <see cref="Authorization"/></returns>
        Task<ApplicationAuthorization> GetOrCreateApplicationAuthorization(
            string clientId,
            string clientSecret,
            NewAuthorization newAuthorization,
            string twoFactorAuthenticationCode);

        /// <summary>
        /// Checks the validity of an OAuth token without running afoul of normal rate limits for failed login attempts.
        /// </summary>
        /// <param name="clientId">Client Id of the OAuth application for the token</param>
        /// <param name="accessToken">The OAuth token to check</param>
        /// <returns>The valid <see cref="ApplicationAuthorization"/></returns>
        Task<ApplicationAuthorization> CheckApplicationAuthentication(string clientId, string accessToken);

        /// <summary>
        /// Revokes a single OAuth token for an OAuth application.
        /// </summary>
        /// <param name="clientId">Client Id of the OAuth application for the token</param>
        /// <param name="accessToken">The OAuth token to check</param>
        /// <returns>The valid <see cref="ApplicationAuthorization"/></returns>
        Task RevokeApplicationAuthentication(string clientId, string accessToken);

        /// <summary>
        /// Updates the specified <see cref="Authorization"/>.
        /// </summary>
        /// <param name="id">Id of the <see cref="Authorization"/> to update</param>
        /// <param name="authorizationUpdate">Describes the changes to make to the authorization</param>
        /// <returns>The updated <see cref="Authorization"/></returns>
        Task<Authorization> Update(int id, AuthorizationUpdate authorizationUpdate);

        /// <summary>
        /// Deletes the specified <see cref="Authorization"/>.
        /// </summary>
        /// <param name="id">The system-wide Id of the authorization to delete</param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// Deletes the specified <see cref="Authorization"/>.
        /// </summary>
        /// <param name="id">The system-wide Id of the authorization to delete</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns></returns>
        Task Delete(int id, string twoFactorAuthenticationCode);
    }
}
