namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    public class Connection : IConnection
    {
        public static readonly Uri DefaultGitLabUri = GitLabClient.GitLabUri;
        private static readonly ICredentialStore AnonymousCredentials = new InMemoryCredentialStore(global::GitLabClient.Credentials.Anonymous);

        private readonly IAuthenticator authenticator;
        private readonly IHttpClient httpClient;

        public Connection(IProductHeaderValue productInformation)
            : this(productInformation, DefaultGitLabUri, AnonymousCredentials)
        {
        }

        public Connection(IProductHeaderValue productInformation, IHttpClient httpClient)
            : this(productInformation, DefaultGitLabUri, AnonymousCredentials, httpClient, new SimpleJsonSerializer())
        {
        }

        public Connection(IProductHeaderValue productInformation, Uri baseAddress)
            : this(productInformation, baseAddress, AnonymousCredentials)
        {
        }

        public Connection(IProductHeaderValue productInformation, ICredentialStore credentialStore)
            : this(productInformation, DefaultGitLabUri, credentialStore)
        {
        }

        public Connection(IProductHeaderValue productInformation, Uri baseAddress, ICredentialStore credentialStore)
            : this(productInformation, baseAddress, credentialStore, new HttpClientA)
        {
        }

        public Task<IApiResponse<string>> GetHtml(Uri uri, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, TimeSpan timeout)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts, CancellationToken cancellationToken)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Patch(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Patch(Uri uri, string accepts)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Patch<T>(Uri uri, object body)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Patch<T>(Uri uri, object body, string accepts)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Post(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, string twoFactorAuthenticationCode)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, TimeSpan timeout)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, Uri baseAddress)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Put(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Put<T>(Uri uri, object body)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<T>> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode, string accepts)
            where T : class
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri, string twoFactoryAuthenticationCode)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri, object data)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri, object data, string accepts)
        {
            throw new NotImplementedException();
        }

        public Uri BaseAddress { get; }

        public ICredentialStore CredentialStore { get; }

        public ICredentials Credentials { get; set; }

        public void SetRequestTimeout(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
    }
}
