namespace GitLabClient
{
    using System;

    public class GitLabClient : IGitLabClient
    {
        public GitLabClient(string applicationName)
        {

        }

        public GitLabClient(IConnection connection)
        {
            Connection = connection;
        }

        public void SetRequestTimeout(TimeSpan timeout)
        {
            Connection.SetRequestTimeout(timeout);
        }

        public IConnection Connection { get; }

        public IAuthorizationsClient Authorization { get; }
    }
}
