namespace Foxkit
{
    using System;

    public class GitLabClient : IGitLabClient
    {
        public static string GitLabUrl { get; set; } = "https://gitlab.com/api/v4/";

        public static Uri GitLabUri => new Uri(GitLabUrl);

        public GitLabClient(string applicationName)
            : this(new ProductHeaderValue(applicationName))
        {
        }

        public GitLabClient(string applicationName, string baseAddress)
            : this(new ProductHeaderValue(applicationName), new Uri(baseAddress))
        {
            GitLabUrl = baseAddress;
        }

        public GitLabClient(string applicationName, Uri baseAddress)
            : this(new ProductHeaderValue(applicationName), baseAddress)
        {
        }

        public GitLabClient(string applicationName, string baseAddress, ICredentials credentials)
            : this(new ProductHeaderValue(applicationName), new InMemoryCredentialStore(credentials), baseAddress)
        {
        }

        public GitLabClient(string applicationName, Uri baseAddress, ICredentials credentials)
            : this(new ProductHeaderValue(applicationName), new InMemoryCredentialStore(credentials), baseAddress)
        {
        }

        public GitLabClient(IProductHeaderValue productInformation)
            : this(new Connection(productInformation, GitLabUri))
        {
        }

        public GitLabClient(IProductHeaderValue productInformation, ICredentials credentials)
            : this(new Connection(productInformation, new InMemoryCredentialStore(credentials)))
        {
        }

        public GitLabClient(IProductHeaderValue productInformation, ICredentialStore credentialStore)
            : this(new Connection(productInformation, credentialStore))
        {
        }

        public GitLabClient(IProductHeaderValue productInformation, string baseAddress)
            : this(productInformation, new Uri(baseAddress))
        {
        }

        public GitLabClient(IProductHeaderValue productInformation, Uri baseAddress)
            : this(new Connection(productInformation, GetApiUri(baseAddress)))
        {
            GitLabUrl = GetApiUri(baseAddress).ToString();
        }

        public GitLabClient(IProductHeaderValue productInformation, ICredentialStore credentialStore, string baseAddress)
            : this(productInformation, credentialStore, new Uri(baseAddress))
        {
        }

        public GitLabClient(IProductHeaderValue productInformation, ICredentialStore credentialStore, Uri baseAddress)
            : this(new Connection(productInformation, GetApiUri(baseAddress), credentialStore))
        {
            GitLabUrl = GetApiUri(baseAddress).ToString();
        }

        public GitLabClient(IConnection connection)
        {
            connection.ArgumentNotNull(nameof(connection));

            var apiConnection = new ApiConnection(connection);

            Connection = apiConnection.Connection;
            User = new UserClient(apiConnection);
        }

        public void SetRequestTimeout(TimeSpan timeout)
        {
            Connection.SetRequestTimeout(timeout);
        }

        public IConnection Connection { get; }

        public IUserClient User { get; }

        private static Uri GetApiUri(Uri uri)
        {
            uri.ArgumentNotNull(nameof(uri));

            if (uri.Host.Contains("api/"))
            {
                uri = new Uri(uri.ToString().Split("api/")[0]);
            }

            return new Uri(uri, new Uri("/api/v4/", UriKind.Relative));
        }
    }
}
