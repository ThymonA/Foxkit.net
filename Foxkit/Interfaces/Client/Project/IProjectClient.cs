namespace Foxkit
{
    using System.Collections.Generic;

    /// <summary>
    /// A client for GitLab's Project API
    /// </summary>
    public interface IProjectClient
    {
        /// <summary>
        /// Returns the <see cref="Project"/> specified by id
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>A <see cref="Project"/></returns>
        Project Get(long id);

        /// <summary>
        /// Returns a list of projects
        /// </summary>
        IReadOnlyList<Project> GetAll { get; }

        /// <summary>
        /// Returns a list of current user projects
        /// </summary>
        IReadOnlyList<Project> GetAllForCurrent { get; }

        /// <summary>
        /// Returns a list of <see cref="Project"/> specified by user id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>A list of <see cref="Project"/></returns>
        IReadOnlyList<Project> GetAllUserProjects(long userId);
    }
}
