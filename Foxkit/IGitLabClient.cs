namespace Foxkit
{
    using System;

    public interface IGitLabClient
    {
        /// <summary>
        /// Set the GitLab Api request timeout.
        /// </summary>
        /// <param name="timeout">The Timeout value</param>
        void SetRequestTimeout(TimeSpan timeout);

        /// <summary>
        /// Provides a client connection to make HTTP requests to endpoints
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// A connection for making API requests against URI endpoints
        /// </summary>
        IApiConnection ApiConnection { get; }

        /// <summary>
        /// Access GitLab's User API.
        /// </summary>
        IUserClient User { get; }

        /// <summary>
        /// Access GitLab's Project API
        /// </summary>
        IProjectClient Project { get; }
    }
}
