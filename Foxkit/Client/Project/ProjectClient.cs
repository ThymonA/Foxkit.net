namespace Foxkit
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ProjectClient : ApiClient, IProjectClient
    {
        public ProjectClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public Project Get(long id)
        {
            id.ArgumentNotNull(nameof(id));

            return ApiConnection.Get<Project>(ApiUrls.Project(id)).Result;
        }

        public IReadOnlyList<Project> GetAllForCurrent
        {
            get
            {
                var currentUser = ApiConnection.CurrentUser;

                if (currentUser.IsNullOrDefault())
                {
                    var newList = new List<Project>();

                    return new ReadOnlyCollection<Project>(newList);
                }

                return ApiConnection.GetAll<Project>(ApiUrls.Projects(currentUser.Id)).Result;
            }
        }

        public IReadOnlyList<Project> GetAll => ApiConnection.GetAll<Project>(ApiUrls.Projects()).Result;

        public IReadOnlyList<Project> GetAllUserProjects(long userId)
        {
            return ApiConnection.GetAll<Project>(ApiUrls.Projects(userId)).Result;
        }
    }
}
