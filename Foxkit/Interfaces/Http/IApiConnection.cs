namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A connection for making API requests against URI endpoints.
    /// </summary>
    public interface IApiConnection
    {
        /// <summary>
        /// Provides a client connection to make HTTP requests to endpoints
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Get the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <returns>The API resource</returns>
        Task<T> Get<T>(Uri uri)
            where T : class;

        /// <summary>
        /// Get the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <returns>The API resource</returns>
        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters)
            where T : class;

        /// <summary>
        /// Get the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns>The API resource</returns>
        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
            where T : class;

        /// <summary>
        /// Gets the HTML content of the API resource at the specified URI.
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <returns></returns>
        Task<string> GetHtml(Uri uri, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets all API resources in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list</returns>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri)
            where T : class;

        /// <summary>
        /// Gets all API resources in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="options">Options for changing the API response</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list</returns>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IApiOptions options)
            where T : class;

        /// <summary>
        /// Gets all API resources in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list</returns>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri, string accepts)
            where T : class;

        /// <summary>
        /// Gets all API resources in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list</returns>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters)
            where T : class;

        /// <summary>
        /// Gets all API resources in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <param name="options">Options for changing the API response</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list</returns>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters, IApiOptions options)
            where T : class;

        /// <summary>
        /// Gets all API resources in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list</returns>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
            where T : class;

        /// <summary>
        /// Gets all API resources in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="options">Options for changing the API response</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list</returns>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters, string accepts, IApiOptions options)
            where T : class;

        /// <summary>
        /// Creates a new API resource in the list at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns></returns>
        Task Post(Uri uri);

        /// <summary>
        /// Creates a new API resource in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <returns>The created API resource</returns>
        Task<T> Post<T>(Uri uri)
            where T : class;

        /// <summary>
        /// Creates a new API resource in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <returns>The created API resource</returns>
        Task<T> Post<T>(Uri uri, object body)
            where T : class;

        /// <summary>
        /// Creates a new API resource in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns>The created API resource</returns>
        Task<T> Post<T>(Uri uri, object body, string accepts)
            where T : class;

        /// <summary>
        /// Creates a new API resource in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="contentType">Specifies the media type of the request body</param>
        /// <returns>The created API resource</returns>
        Task<T> Post<T>(Uri uri, object body, string accepts, string contentType)
            where T : class;

        /// <summary>
        /// Creates a new API resource in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="contentType">Specifies the media type of the request body</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns>The created API resource</returns>
        Task<T> Post<T>(Uri uri, object body, string accepts, string contentType, string twoFactorAuthenticationCode)
            where T : class;

        /// <summary>
        /// Creates a new API resource in the list at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <param name="contentType">Specifies the media type of the request body</param>
        /// <param name="timeout">Expiration time of the request</param>
        /// <returns>The created API resource</returns>
        Task<T> Post<T>(Uri uri, object body, string accepts, string contentType, TimeSpan timeout)
            where T : class;

        /// <summary>
        /// Creates or replaces the API resource at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns></returns>
        Task Put(Uri uri);

        /// <summary>
        /// Creates or replaces the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <returns>The created API resource</returns>
        Task<T> Put<T>(Uri uri, object body)
            where T : class;

        /// <summary>
        /// Creates or replaces the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns>The created API resource</returns>
        Task<T> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode)
            where T : class;

        /// <summary>
        /// Creates or replaces the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns>The created API resource</returns>
        Task<T> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode, string accepts)
            where T : class;

        /// <summary>
        /// Update the API resource at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns></returns>
        Task Patch(Uri uri);

        /// <summary>
        /// Update the API resource at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns></returns>
        Task Patch(Uri uri, string accepts);

        /// <summary>
        /// Update the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <returns></returns>
        Task<T> Patch<T>(Uri uri, object body)
            where T : class;

        /// <summary>
        /// Update the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns></returns>
        Task<T> Patch<T>(Uri uri, object body, string accepts)
            where T : class;

        /// <summary>
        /// Deletes the API object at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <returns></returns>
        Task Delete(Uri uri);

        /// <summary>
        /// Deletes the API object at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="twoFactorAuthenticationCode">Two factory authentication code</param>
        /// <returns></returns>
        Task Delete(Uri uri, string twoFactorAuthenticationCode);

        /// <summary>
        /// Deletes the API object at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <returns></returns>
        Task Delete(Uri uri, object body);

        /// <summary>
        /// Deletes the API object at the specified URI
        /// </summary>
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns></returns>
        Task Delete(Uri uri, object body, string accepts);

        /// <summary>
        /// Executes a GET to the API object at the specified URI. This operation is appropriate for API calls which 
        /// queue long running calculations and return a collection of a resource.
        /// It expects the API to respond with an initial 202 Accepted, and queries again until a 200 OK is received.
        /// It returns an empty collection if it receives a 204 No Content response.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetQueuedOperation<T>(Uri uri, CancellationToken cancellationToken)
            where T : class;
    }
}
