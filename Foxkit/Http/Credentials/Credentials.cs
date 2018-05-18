namespace Foxkit
{
    public class Credentials : ICredentials
    {
        public static ICredentials Anonymous => new Credentials();

        public Credentials()
        {
            AuthenticationType = AuthenticationType.Anonymous;
        }

        public Credentials(string token)
            : this(token, AuthenticationType.Oauth)
        {
        }

        public Credentials(string token, AuthenticationType authenticationType)
        {
            token.ArgumentNotNullOrEmptyString(nameof(token));

            Login = null;
            Password = token;
            AuthenticationType = authenticationType;
        }

        public Credentials(string login, string password)
            : this(login, password, AuthenticationType.Basic)
        {
        }

        public Credentials(string login, string password, AuthenticationType authenticationType)
        {
            login.ArgumentNotNullOrEmptyString(nameof(login));
            password.ArgumentNotNullOrEmptyString(nameof(password));

            Login = login;
            Password = password;
            AuthenticationType = authenticationType;
        }

        public string Login { get; }

        public string Password { get; }

        public AuthenticationType AuthenticationType { get; }
    }
}
