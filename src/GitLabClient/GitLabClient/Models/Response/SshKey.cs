namespace GitLabClient
{
    using System;

    public class SshKey
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Key { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
