namespace Foxkit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static class ApiExtensions
    {
        /// <summary>
        /// Gets the API resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource to get.</typeparam>
        /// <param name="connection">The connection to use</param>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="cancellationToken">A token used to cancel the GetResponse request</param>
        /// <returns>The API resource.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        public static Task<IApiResponse<T>> GetResponse<T>(this IConnection connection, Uri uri, CancellationToken cancellationToken)
            where T : class
        {
            connection.ArgumentNotNull(nameof(connection));
            uri.ArgumentNotNull(nameof(uri));

            return connection.Get<T>(uri, null, null, cancellationToken);
        }
    }
}
