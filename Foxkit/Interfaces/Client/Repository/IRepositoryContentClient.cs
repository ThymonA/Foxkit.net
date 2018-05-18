namespace Foxkit
{
    using System.Collections.Generic;

    public interface IRepositoryContentClient
    {
        /// <summary>
        /// Returns the contents of the root directory in a repository
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <returns>A list of <see cref="RepositoryContent"/></returns>
        IReadOnlyList<RepositoryContent> GetAllContents(long repositoryId);
    }
}
