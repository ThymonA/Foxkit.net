namespace GitLabClient
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Authenticator : IAuthenticator
    {
        private static IDictionary<AuthenticationType, IAuthenticationHandler> Authenticators =>
            new Dictionary<AuthenticationType, IAuthenticationHandler>
            {
                { AuthenticationType.Anonymous, new AnonymousAuthenticator() },
                { AuthenticationType.Basic, new BasicAuthenticator() },
                { AuthenticationType.Oauth, new TokenAuthenticator() },
                { AuthenticationType.Bearer, new BearerTokenAuthenticator() }
            };

        public Authenticator(ICredentialStore credentialStore)
        {
            credentialStore.ArgumentNotNull(nameof(credentialStore));

            CredentialStore = credentialStore;
        }

        public async Task Apply(IRequest request)
        {
            request.ArgumentNotNull(nameof(request));

            var credentials = await CredentialStore.GetCredentials().ConfigureAwait(false) ?? Credentials.Anonymous;

            Authenticators[credentials.AuthenticationType].Authenticate(request, credentials);
        }

        public ICredentialStore CredentialStore { get; set; }
    }
}
