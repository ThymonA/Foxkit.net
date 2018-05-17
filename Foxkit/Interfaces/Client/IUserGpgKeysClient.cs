namespace Foxkit
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// A client for GitLab's User GPG Keys API
    /// </summary>
    public interface IUserGpgKeysClient
    {
        /// <summary>
        /// Gets all GPG keys for current authenticated user
        /// </summary>
        /// <returns>A <see cref="IReadOnlyList{GpgKey}"/> of <see cref="GpgKey"/>s for the current user.</returns>
        Task<IReadOnlyList<GpgKey>> GetAllForCurrent();

        /// <summary>
        /// Gets all GPG keys for current authenticated user
        /// </summary>
        /// <param name="options">
        /// Options for changing the API response
        /// </param>
        /// <returns>
        /// A <see cref="IReadOnlyList{GpgKey}"/> of <see cref="GpgKey"/>s for the current user.
        /// </returns>
        Task<IReadOnlyList<GpgKey>> GetAllForCurrent(IApiOptions options);

        /// <summary>
        /// View extended details of the <see cref="GpgKey"/> for the speciefied id
        /// </summary>
        /// <param name="id">The Id of the GPG key</param>
        /// <returns>A <see cref="GpgKey"/></returns>
        Task<GpgKey> Get(long id);

        /// <summary>
        /// Creates a new <see cref="GpgKey"/> for the authenticated user.
        /// </summary>
        /// <param name="newGpgKey">The new GPG key</param>
        /// <returns>The newly created <see cref="GpgKey"/></returns>
        Task<GpgKey> Create(NewGpgKey newGpgKey);

        /// <summary>
        /// Deletes the GPG key for the speciefied id
        /// </summary>
        /// <param name="id">The Id of the GPG key</param>
        /// <returns>A <see cref="HttpStatusCode"/></returns>
        Task Delete(long id);
    }
}
