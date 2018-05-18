namespace Foxkit
{
    /// <summary>
    /// A client for GitLab's Repository API
    /// </summary>
    public interface IRepositoryClient
    {
        /// <summary>
        /// A client for GitLab's Repository Content API
        /// </summary>
        IRepositoryContentClient Content { get; }
    }
}
