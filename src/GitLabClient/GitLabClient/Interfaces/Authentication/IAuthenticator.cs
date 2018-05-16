namespace GitLabClient
{
    using System.Threading.Tasks;

    public interface IAuthenticator
    {
        Task Apply(IRequest request);

        ICredentialStore CredentialStore { get; set; }
    }
}
