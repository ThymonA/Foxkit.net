namespace GitLabClient
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
        /// Access GitLab's Authorization API.
        /// </summary>
        IAuthorizationsClient Authorization { get; }
    }
}
