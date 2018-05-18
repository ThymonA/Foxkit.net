namespace Foxkit
{
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class ApiOptions : IApiOptions
    {
        public static IApiOptions None => new ApiOptions();

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        internal string DebuggerDisplay
        {
            get
            {
                var values = new List<string>();

                if (StartPage.HasValue)
                {
                    values.Add("StartPage: " + StartPage.Value);
                }

                if (PageCount.HasValue)
                {
                    values.Add("PageCount: " + PageCount.Value);
                }

                if (PageSize.HasValue)
                {
                    values.Add("PageSize: " + PageSize.Value);
                }

                return string.Join(", ", values);
            }
        }
    }
}
