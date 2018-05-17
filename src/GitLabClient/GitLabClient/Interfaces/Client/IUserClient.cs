namespace Foxkit
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// A client for GitLab's Users API
    /// </summary>
    public interface IUserClient
    {
        /// <summary>
        /// A client for GitLab's User SSH Keys API
        /// </summary>
        IUserSshKeysClient SshKey { get; }

        /// <summary>
        /// A client for GitLab's User GPG Keys API
        /// </summary>
        IUserGpgKeysClient GpgKey { get; }

        /// <summary>
        /// Returns the user specified by the login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>A <see cref="User"/></returns>
        Task<User> Get(string login);

        /// <summary>
        /// Returns a list of users
        /// </summary>
        /// <returns>A list of <see cref="User"/></returns>
        Task<IReadOnlyList<User>> GetAll();

        /// <summary>
        /// Returns a <see cref="User"/> for the current authenticated user
        /// </summary>
        /// <returns>A <see cref="User"/></returns>
        Task<User> Current();

        /// <summary>
        /// Update the specified <see cref="UserUpdate"/>.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> Update(UserUpdate user);
    }
}
