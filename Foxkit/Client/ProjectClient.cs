namespace Foxkit
{
    using System;
    using System.Collections.Generic;

    public class ProjectClient : ApiClient, IProjectClient
    {
        private Uri CurrentUserUrl => ApiUrls.Projects(ApiConnection.CurrentUser.Id);

        public ProjectClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public Project Get(long id)
        {
            id.ArgumentNotNull(nameof(id));

            return ApiConnection.Get<Project>(ApiUrls.Project(id)).Result;
        }

        public IReadOnlyList<Project> GetAllFromCurrentUser => ApiConnection.GetAll<Project>(CurrentUserUrl).Result;

        public IReadOnlyList<Project> GetAll => ApiConnection.GetAll<Project>(ApiUrls.Projects()).Result;

        public IReadOnlyList<Project> GetAllUserProjects(long userId)
        {
            return ApiConnection.GetAll<Project>(ApiUrls.Projects(userId)).Result;
        }
    }
}
