namespace Foxkit
{
    using System;
    using System.Globalization;

    public class TokenAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(IRequest request, ICredentials credentials)
        {
            request.ArgumentNotNull(nameof(request));
            credentials.ArgumentNotNull(nameof(credentials));
            credentials.Password.ArgumentNotNull(nameof(credentials.Password));

            var token = credentials.Password;

            if (credentials.Login != null)
            {
                throw new InvalidOperationException("The login must be null for token authentication requests.");
            }

            if (token != null)
            {
                request.Headers["Authorization"] = string.Format(CultureInfo.InvariantCulture, "Token {0}", token);
            }
        }
    }
}
