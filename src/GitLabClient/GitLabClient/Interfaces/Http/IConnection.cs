namespace GitLabClient.Interfaces.Http
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
        /// <param name="uri">URI endpoint</param>
        /// <param name="body">The object to serialize as the body of the request</param>
        /// <returns><seealso cref="IResponse"/>Represents a generic HTTP response</returns>
        Task<IApiResponse<T>> Patch<T>(Uri uri, object body)
            where T : class;
    }
}
