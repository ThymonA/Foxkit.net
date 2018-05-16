namespace GitLabClient
{
    using System;

    public static class ApiInfoExtensions
    {
        public static Uri GetPreviousPageUrl(this IApiInfo info)
        {
            info.ArgumentNotNull(nameof(info));

            return info.Links.SafeGet("prev");
        }

        public static Uri GetNextPageUrl(this IApiInfo info)
        {
            info.ArgumentNotNull(nameof(info));

            return info.Links.SafeGet("next");
        }

        public static Uri GetFirstPageUrl(this IApiInfo info)
        {
            info.ArgumentNotNull(nameof(info));

            return info.Links.SafeGet("first");
        }

        public static Uri GetLastPageUrl(this IApiInfo info)
        {
            info.ArgumentNotNull(nameof(info));

            return info.Links.SafeGet("last");
        }
    }
}
