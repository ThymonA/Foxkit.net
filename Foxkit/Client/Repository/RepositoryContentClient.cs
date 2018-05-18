namespace Foxkit.Client.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class RepositoryContentClient : ApiClient, IRepositoryContentClient
    {
        public RepositoryContentClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the contents of the root directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <returns>A list of <see cref="T:Foxkit.RepositoryContent" /></returns>
        public IReadOnlyList<RepositoryContent> GetAllContents(long projectId)
        {
            projectId.ArgumentNotNull(nameof(projectId));

            return GetAllContents(projectId, ApiUrls.RepositoryContent(projectId));
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">Directory path</param>
        /// <returns>A list of <see cref="T:Foxkit.RepositoryContent" /></returns>
        public IReadOnlyList<RepositoryContent> GetAllContents(long projectId, string path)
        {
            projectId.ArgumentNotNull(nameof(projectId));
            path.ArgumentNotNullOrEmptyString(nameof(path));

            return GetAllContents(projectId, ApiUrls.RepositoryContent(projectId, path));
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">Directory path</param>
        /// <param name="branch">Repository branch</param>
        /// <returns>A list of <see cref="T:Foxkit.RepositoryContent" /></returns>
        public IReadOnlyList<RepositoryContent> GetAllContents(long projectId, string path, string branch)
        {
            projectId.ArgumentNotNull(nameof(projectId));
            path.ArgumentNotNullOrEmptyString(nameof(path));
            branch.ArgumentNotNullOrEmptyString(nameof(branch));

            return GetAllContents(projectId, ApiUrls.RepositoryContent(projectId, path, branch));
        }

        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="contentUri">The url from <see cref="ApiUrls"/></param>
        /// <returns>A list of <see cref="RepositoryContent"/></returns>
        private IReadOnlyList<RepositoryContent> GetAllContents(long projectId, Uri contentUri)
        {
            var project = ApiConnection.Get<Project>(ApiUrls.Project(projectId)).Result;
            var contents = ApiConnection.GetAll<RepositoryContent>(contentUri).Result.ToList();

            foreach (var content in contents.Where(x => x.ContentType == ContentType.File || x.ContentType == ContentType.Executable))
            {
                var contentFile = ApiConnection.Get<RepositoryFile>(ApiUrls.RepositoryFile(projectId, content.Path)).Result;

                contentFile.GitUrl = ApiUrls.RepositoryFile(projectId, content.Path).ToString();
                contentFile.HtmlUrl = $"{project.WebUrl}/blob/{content.Branch}/{content.Name}";
                contentFile.RawUrl = $"{project.WebUrl}/raw/{content.Branch}/{content.Name}";
            }

            return new ReadOnlyCollection<RepositoryContent>(contents);
        }
    }
}
