namespace GitLabClient
{
    using System;

    using GitLabClient.Helpers.Extensions;

    public static class ApiUrls
    {
        public static Uri Users()
        {
            return "users/".FormatUri();
        }

        public static Uri User(string login)
        {
            return "user/{0}".FormatUri(login);
        }
    }
}
