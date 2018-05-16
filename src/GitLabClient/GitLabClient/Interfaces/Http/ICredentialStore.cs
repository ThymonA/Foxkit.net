namespace GitLabClient
{
    using System.Threading.Tasks;

    /// <summary>
    /// Abstraction for interacting with credentials
    /// </summary>
    public interface ICredentialStore
    {
        /// <summary>
        /// Retrieve the credentials from the store
        /// </summary>
        /// <returns></returns>
        Task<ICredentials> GetCredentials();
    }
}
