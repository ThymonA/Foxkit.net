namespace Foxkit
{
    using System.Collections.Generic;

    /// <summary>
    /// A client for GitLab's Repository Content API
    /// </summary>
    public interface IRepositoryContentClient
    {
        /// <summary>
        /// Returns the contents of the root directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <returns>A list of <see cref="RepositoryContent"/></returns>
        IReadOnlyList<RepositoryContent> GetAllContents(long projectId);

        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">Directory path</param>
        /// <returns>A list of <see cref="RepositoryContent"/></returns>
        IReadOnlyList<RepositoryContent> GetAllContents(long projectId, string path);

        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">Directory path</param>
        /// <param name="branch">Repository branch</param>
        /// <returns>A list of <see cref="RepositoryContent"/></returns>
        IReadOnlyList<RepositoryContent> GetAllContents(long projectId, string path, string branch);
    }
}
