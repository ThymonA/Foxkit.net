namespace GitLabClient
{
    using System;

    public class Account
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string State { get; set; }

        public string AvatarUrl { get; set; }

        public string WebUrl { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string Bio { get; set; }

        public string Location { get; set; }

        public string Skype { get; set; }

        public string LinkedIn { get; set; }

        public string Twitter { get; set; }

        public string WebsiteUrl { get; set; }

        public DateTimeOffset LastSignInAt { get; set; }

        public DateTimeOffset ConfirmedAt { get; set; }

        public DateTime LastActivityOn { get; set; }

        public string Email { get; set; }

        public int ThemeId { get; set; }

        public int ColorSchemeId { get; set; }

        public int ProjectsLimit { get; set; }

        public DateTimeOffset CurrentSignInAt { get; set; }

        public bool CanCreateGroup { get; set; }

        public bool CanCreateProject { get; set; }

        public bool TwoFactoryEnabled { get; set; }

        public bool External { get; set; }
    }
}
