namespace Foxkit
{
    using System;

    public static class ApiUrls
    {
        public static Uri User()
        {
            return "user/".FormatUri();
        }

        public static Uri Users()
        {
            return "users/".FormatUri();
        }

        public static Uri User(string login)
        {
            return "user/{0}".FormatUri(login);
        }

        public static Uri SshKeys()
        {
            return "user/keys/".FormatUri();
        }

        public static Uri SshKeys(long id)
        {
            return "user/keys/{0}".FormatUri(id);
        }

        public static Uri GpgKeys()
        {
            return "user/gpg_keys/".FormatUri();
        }

        public static Uri GpgKeys(long id)
        {
            return "user/gpg_keys/{0}".FormatUri(id);
        }

        public static Uri Project(long id)
        {
            return "projects/{0}".FormatUri(id);
        }

        public static Uri Projects()
        {
            return "projects/".FormatUri();
        }

        public static Uri Projects(long id)
        {
            return "users/{0}/projects/".FormatUri(id);
        }

        public static Uri RepositoryContent(long projectId)
        {
            return "projects/{0}/repository/tree/".FormatUri(projectId);
        }

        public static Uri RepositoryContent(long projectId, string path)
        {
            return "projects/{0}/repository/tree/?path={1}".FormatUri(projectId, path.UrlEncode());
        }

        public static Uri RepositoryContent(long projectId, string path, string branch)
        {
            return "projects/{0}/repository/tree/?path={1}&ref={2}".FormatUri(projectId, path.UrlEncode(), branch);
        }

        public static Uri RepositoryFile(long projectId, string filePath)
        {
            return "projects/{0}/repository/files/{1}/?ref=master".FormatUri(projectId, filePath.UrlEncode());
        }

        public static Uri RepositoryFile(long projectId, string filePath, string branch)
        {
            return "projects/{0}/repository/files/{1}/?ref={2}".FormatUri(projectId, filePath.UrlEncode(), branch);
        }
    }
}
