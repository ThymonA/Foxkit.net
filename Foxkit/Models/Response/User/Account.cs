namespace Foxkit
{
    using System;

    using Newtonsoft.Json;

    public class Account
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("skype")]
        public string Skype { get; set; }

        [JsonProperty("linkedin")]
        public string LinkedIn { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("last_sign_in_at")]
        public DateTimeOffset LastSignInAt { get; set; }

        [JsonProperty("confirmed_at")]
        public DateTimeOffset ConfirmedAt { get; set; }

        [JsonProperty("last_activity_on")]
        public DateTime LastActivityOn { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("theme_id")]
        public int ThemeId { get; set; }

        [JsonProperty("color_scheme_id")]
        public int ColorSchemeId { get; set; }

        [JsonProperty("projects_limit")]
        public int ProjectsLimit { get; set; }

        [JsonProperty("current_sign_in_at")]
        public DateTimeOffset CurrentSignInAt { get; set; }

        [JsonProperty("can_create_group")]
        public bool CanCreateGroup { get; set; }

        [JsonProperty("can_create_project")]
        public bool CanCreateProject { get; set; }

        [JsonProperty("two_factor_enabled")]
        public bool TwoFactoryEnabled { get; set; }

        [JsonProperty("external")]
        public bool External { get; set; }
    }
}
