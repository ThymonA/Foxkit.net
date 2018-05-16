namespace GitLabClient
{
    public interface IAuthenticationHandler
    {
        void Authenticate(IRequest request, ICredentials credentials);
    }
}
