namespace GitLabClient
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// A client for GitLab's User SSH Keys API
    /// </summary>
    public interface IUserSshKeysClient
    {
        /// <summary>
        /// Gets all SSH keys for current authenticated user
        /// </summary>
        /// <returns>A <see cref="IReadOnlyList{SshKey}"/> of <see cref="SshKey"/>s for the current user.</returns>
        Task<IReadOnlyList<SshKey>> GetAllForCurrent();

        /// <summary>
        /// Gets all SSH keys for current authenticated user
        /// </summary>
        /// <param name="options">
        /// Options for changing the API response
        /// </param>
        /// <returns>
        /// A <see cref="IReadOnlyList{SshKey}"/> of <see cref="SshKey"/>s for the current user.
        /// </returns>
        Task<IReadOnlyList<SshKey>> GetAllForCurrent(IApiOptions options);

        /// <summary>
        /// View extended details of the <see cref="SshKey"/> for the speciefied id
        /// </summary>
        /// <param name="id">The Id of the SSH key</param>
        /// <returns>A <see cref="SshKey"/></returns>
        Task<SshKey> Get(long id);

        /// <summary>
        /// Creates a new <see cref="SshKey"/> for the authenticated user.
        /// </summary>
        /// <param name="newGpgKey">The new SSH key</param>
        /// <returns>The newly created <see cref="SshKey"/></returns>
        Task<SshKey> Create(NewSshKey newGpgKey);

        /// <summary>
        /// Deletes the SSH key for the speciefied id
        /// </summary>
        /// <param name="id">The Id of the SSH key</param>
        /// <returns></returns>
        Task Delete(long id);
    }
}
