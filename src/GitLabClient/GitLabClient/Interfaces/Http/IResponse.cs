namespace GitLabClient.Interfaces.Http
{
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Represents a generic HTTP response
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Raw response body
        /// </summary>
        object Body { get; }

        /// <summary>
        /// Information about the API
        /// </summary>
        IReadOnlyDictionary<string, string> Headers { get; }

        /// <summary>
        /// Information about the API response parsed from the response headers
        /// </summary>
        IApiInfo ApiInfo { get; }

        /// <summary>
        /// The response status code
        /// </summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The content type of the response
        /// </summary>
        string ContentType { get; }
    }
}
