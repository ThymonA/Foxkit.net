namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
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
        Task<T> Get<T>(Uri uri);

        /// <summary>
        /// Get the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <returns>The API resource</returns>
        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters);

        /// <summary>
        /// Get the API resource at the specified URI
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="uri">URI endpoint</param>
        /// <param name="parameters">Querystring parameters</param>
        /// <param name="accepts">Specifies accepted response media types</param>
        /// <returns>The API resource</returns>
        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts);

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
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri);
    }
}
