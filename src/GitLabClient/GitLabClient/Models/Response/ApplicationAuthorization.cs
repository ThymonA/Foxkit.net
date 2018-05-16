namespace GitLabClient
{
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class ApplicationAuthorization : Authorization
    {
        public string Token { get; set; }
    }
}
