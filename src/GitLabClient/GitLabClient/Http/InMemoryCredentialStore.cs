namespace GitLabClient
{
    using System.Threading.Tasks;

    /// <summary>
    /// Abstraction for interacting with credentials
    /// </summary>
    public class InMemoryCredentialStore : ICredentialStore
    {
        private readonly ICredentials credentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryCredentialStore"/> class.
        /// </summary>
        /// <param name="credentials"><see cref="ICredentials"/></param>
        public InMemoryCredentialStore(ICredentials credentials)
        {
            credentials.ArgumentNotNull(nameof(credentials));

            this.credentials = credentials;
        }

        /// <summary>
        /// Retrieve the credentials from <see cref="credentials"/>
        /// </summary>
        /// <returns><see cref="ICredentials"/></returns>
        public Task<ICredentials> GetCredentials()
        {
            return Task.FromResult(credentials);
        }
    }
}
