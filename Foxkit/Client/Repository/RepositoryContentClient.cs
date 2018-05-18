namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <inheritdoc cref="IRepositoryContentClient" />
    /// <summary>
    /// A client for GitLab's Repository Content API
    /// </summary>
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
        public IReadOnlyList<IRepositoryContent> GetAllContents(long projectId)
        {
            projectId.ArgumentNotNull(nameof(projectId));

            return GetAllContents(
                projectId,
                ApiUrls.RepositoryContent(projectId),
                ApiUrls.RepositoryFile(projectId, "/"));
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">Directory path</param>
        /// <returns>A list of <see cref="T:Foxkit.RepositoryContent" /></returns>
        public IReadOnlyList<IRepositoryContent> GetAllContents(long projectId, string path)
        {
            projectId.ArgumentNotNull(nameof(projectId));
            path.ArgumentNotNullOrEmptyString(nameof(path));

            return GetAllContents(
                projectId,
                ApiUrls.RepositoryContent(projectId, path),
                ApiUrls.RepositoryFile(projectId, path));
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">Directory path</param>
        /// <param name="branch">Repository branch</param>
        /// <returns>A list of <see cref="T:Foxkit.RepositoryContent" /></returns>
        public IReadOnlyList<IRepositoryContent> GetAllContents(long projectId, string path, string branch)
        {
            projectId.ArgumentNotNull(nameof(projectId));
            path.ArgumentNotNullOrEmptyString(nameof(path));
            branch.ArgumentNotNullOrEmptyString(nameof(branch));

            return GetAllContents(
                projectId,
                ApiUrls.RepositoryContent(projectId, path, branch),
                ApiUrls.RepositoryFile(projectId, path, branch));
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the content of the given file in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">File path</param>
        /// <returns>A list of <see cref="T:Foxkit.RepositoryContent" /></returns>
        public RepositoryFile GetFile(long projectId, string path)
        {
            projectId.ArgumentNotNull(nameof(projectId));
            path.ArgumentNotNullOrEmptyString(nameof(path));

            return GetFile(
                projectId,
                ApiUrls.RepositoryFile(projectId, path));
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the content of the given file in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="path">File path</param>
        /// <param name="branch">Repository branch</param>
        /// <returns>A list of <see cref="T:Foxkit.RepositoryContent" /></returns>
        public RepositoryFile GetFile(long projectId, string path, string branch)
        {
            projectId.ArgumentNotNull(nameof(projectId));
            path.ArgumentNotNullOrEmptyString(nameof(path));
            branch.ArgumentNotNullOrEmptyString(nameof(branch));

            return GetFile(
                projectId,
                ApiUrls.RepositoryFile(projectId, path, branch));
        }

        /// <summary>
        /// Returns the contents of the given directory in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="endpointContent">The endpoint url to content</param>
        /// <param name="endpointFile">The endpoint url to file</param>
        /// <returns>A list of <see cref="RepositoryContent"/></returns>
        private IReadOnlyList<IRepositoryContent> GetAllContents(long projectId, Uri endpointContent, Uri endpointFile)
        {
            var project = ApiConnection.Get<Project>(ApiUrls.Project(projectId)).Result;
            var contents = ApiConnection.GetAll<RepositoryContent>(endpointContent).Result.ToList();

            foreach (var content in contents.Where(x => x.ContentType == ContentType.File || x.ContentType == ContentType.Executable))
            {
                var contentFile = ApiConnection.Get<RepositoryFile>(endpointFile).Result;

                contentFile.GitUrl = ApiUrls.RepositoryFile(projectId, content.Path).ToString();
                contentFile.HtmlUrl = $"{project.WebUrl}/blob/{content.Branch}/{content.Name}";
                contentFile.RawUrl = $"{project.WebUrl}/raw/{content.Branch}/{content.Name}";

                content.RepositoryFile = contentFile;
            }

            return new ReadOnlyCollection<RepositoryContent>(contents);
        }

        /// <summary>
        /// Returns the content of the given file in a repository
        /// </summary>
        /// <param name="projectId">The Id of the repository</param>
        /// <param name="endpoint">The endpoint url to file</param>
        /// <returns>A list of <see cref="RepositoryContent"/></returns>
        private RepositoryFile GetFile(long projectId, Uri endpoint)
        {
            var project = ApiConnection.Get<Project>(ApiUrls.Project(projectId)).Result;
            var contentFile = ApiConnection.Get<RepositoryFile>(endpoint).Result;

            contentFile.GitUrl = ApiUrls.RepositoryFile(projectId, contentFile.Path).ToString();
            contentFile.HtmlUrl = $"{project.WebUrl}/blob/{contentFile.Branch}/{contentFile.Name}";
            contentFile.RawUrl = $"{project.WebUrl}/raw/{contentFile.Branch}/{contentFile.Name}";

            return contentFile;
        }
    }
}
