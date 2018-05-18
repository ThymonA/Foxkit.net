namespace Foxkit
{
    public class RepositoryClient : ApiClient, IRepositoryClient
    {
        public RepositoryClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
            Content = new RepositoryContentClient(apiConnection);
        }

        /// <inheritdoc />
        /// <summary>
        /// A client for GitLab's Repository Content API
        /// </summary>
        public IRepositoryContentClient Content { get; }
    }
}
