namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IConnection
    {
        /// <summary>
        /// Performs an asynchronous HTTP GET request that expects a <seealso cref="IResponse"/> containing HTML.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<string>> GetHtml(Uri uri, IDictionary<string, string> parameters);

        /// <summary>
        /// Performs an asynchronous HTTP GET request that expects a <seealso cref="IResponse"/> containing <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="timeout">Expiration time of the request</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Get<T>(Uri uri, TimeSpan timeout)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP GET request that expects a <seealso cref="IResponse"/> containing <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP GET request that expects a <seealso cref="IResponse"/> containing <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="cancellationToken">A token used to cancel the GET request</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts, CancellationToken cancellationToken)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP PATCH request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Patch(Uri uri);

        /// <summary>
        /// Performs an asynchronous HTTP PATCH request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Patch(Uri uri, string accepts);

        /// <summary>
        /// Performs an asynchronous HTTP PATCH request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Patch<T>(Uri uri, object body)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP PATCH request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Patch<T>(Uri uri, object body, string accepts)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP POST request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Post(Uri uri);

        /// <summary>
        /// Performs an asynchronous HTTP POST request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Post<T>(Uri uri)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP POST request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="contentType">Specifies the media type of the request body</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP POST request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="contentType">Specifies the media type of the request body</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, string twoFactorAuthenticationCode)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP POST request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="contentType">Specifies the media type of the request body</param>
        /// <param name="timeout">Expiration time of the request</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, TimeSpan timeout)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP POST request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="contentType">Specifies the media type of the request body</param>
        /// <param name="baseAddress">Allows overriding the base address for a post</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, Uri baseAddress)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP PUT request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Put(Uri uri);

        /// <summary>
        /// Performs an asynchronous HTTP PUT request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The body of the request</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Put<T>(Uri uri, object body)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP PUT request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The body of the request</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP PUT request.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The body of the request</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode, string accepts)
            where T : class;

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Delete(Uri uri);

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="twoFactoryAuthenticationCode">Two factory authentication code</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Delete(Uri uri, string twoFactoryAuthenticationCode);

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="data">The body of the request</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Delete(Uri uri, object data);

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="data">The body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns><seealso cref="HttpStatusCode"/>HTTP status code</returns>
        Task<HttpStatusCode> Delete(Uri uri, object data, string accepts);

        /// <summary>
        /// Base address for the connection
        /// </summary>
        Uri BaseAddress { get; }

        /// <summary>
        /// Get she <seealso cref="ICredentialStore"/> used to provide credentials for the connection
        /// </summary>
        ICredentialStore CredentialStore { get; }

        /// <summary>
        /// Gets or sets the credentials used by the connection.
        /// </summary>
        ICredentials Credentials { get; set; }

        /// <summary>
        /// Set the GitLab API request timeout.
        /// </summary>
        /// <param name="timeout">The Timeout value</param>
        void SetRequestTimeout(TimeSpan timeout);
    }
}
