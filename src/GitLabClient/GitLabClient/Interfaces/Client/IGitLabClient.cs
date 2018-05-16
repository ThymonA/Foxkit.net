namespace GitLabClient.Interfaces.Client
{
    using System;

    public interface IGitLabClient
    {
        /// <summary>
        /// Set the GitLab Api request timeout.
        /// </summary>
        /// <param name="timeout">The Timeout value</param>
        void SetRequestTimeout(TimeSpan timeout);
    }
}
