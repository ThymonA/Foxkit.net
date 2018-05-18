namespace Foxkit
{
    /// <summary>
    /// Base class for an API Client
    /// </summary>
    public abstract class ApiClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class
        /// </summary>
        /// <param name="apiConnection">
        /// The client's connection
        /// </param>
        protected ApiClient(IApiConnection apiConnection)
        {
            apiConnection.ArgumentNotNull(nameof(apiConnection));

            ApiConnection = apiConnection;
            Connection = apiConnection.Connection;
        }

        /// <summary>
        /// Gets the API Client's connection
        /// </summary>
        protected IApiConnection ApiConnection { get; }

        /// <summary>
        /// Returns the underlying <see cref="IConnection"/> used by the <see cref="IApiConnection"/>
        /// </summary>
        protected IConnection Connection { get; }
    }
}
