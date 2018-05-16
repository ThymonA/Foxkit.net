namespace GitLabClient
{
    using System;
    using System.Diagnostics;
    using System.Net;

    /// <summary>
    /// Represents a HTTP 404 - Not Found response returned from the API.
    /// </summary>
    #if !NO_SERIALIZABLE
    [Serializable]
    #endif
    public class NotFoundException : ApiException
    {
        public NotFoundException(IResponse response)
            : this(response, null)
        {
        }

        public NotFoundException(string message, HttpStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public NotFoundException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.NotFound, "NotFoundException wrong status code");
        }
    }
}
