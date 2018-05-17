namespace Foxkit
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;

    public class BasicAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(IRequest request, ICredentials credentials)
        {
            request.ArgumentNotNull(nameof(request));
            credentials.ArgumentNotNull(nameof(credentials));
            credentials.Login.ArgumentNotNull(nameof(credentials.Login));

            Debug.Assert(credentials.Password != null, "password can't not be null");

            var header = string.Format(
                CultureInfo.InvariantCulture,
                "Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", credentials.Login, credentials.Password))));

            request.Headers["Authorization"] = header;
        }
    }
}
