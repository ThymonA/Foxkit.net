namespace GitLabClient
{
    using System;

    public class GitLabClient : IGitLabClient
    {
        public static readonly Uri GitLabUri = new Uri("https://gitlab.com/");

        public GitLabClient(string applicationName)
        {

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

        public IAuthorizationsClient Authorization { get; }

        public IUserClient User { get; }
    }
}
