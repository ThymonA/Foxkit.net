namespace Foxkit.Client.Repository
{
    public class RepositoryClient : ApiClient, IRepositoryClient
    {
        public RepositoryClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
            Content = new RepositoryContentClient(apiConnection);
        }

        public IRepositoryContentClient Content { get; }
    }
}
