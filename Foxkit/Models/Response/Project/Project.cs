namespace Foxkit
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Project
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_with_namespace")]
        public string NameWithNamespace { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("path_with_namespace")]
        public string PathWithNamespace { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("tag_list")]
        public List<string> Tags { get; set; }

        [JsonProperty("ssh_url_to_repo")]
        public string SshUrl { get; set; }

        [JsonProperty("http_url_to_repo")]
        public string HttpUrl { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("star_count")]
        public int StarCount { get; set; }

        [JsonProperty("forks_count")]
        public int ForksCount { get; set; }

        [JsonProperty("last_activity_at")]
        public DateTimeOffset LastActivityAt { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, string> Links { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("owner")]
        public User Owner { get; set; }

        [JsonProperty("container_registry_enabled")]
        public bool ContainerRegistryEnabled { get; set; }

        [JsonProperty("issues_enabled")]
        public bool IssuesEnabled { get; set; }

        [JsonProperty("merge_requests_enabled")]
        public bool MergeRequestsEnabled { get; set; }

        [JsonProperty("wiki_enabled")]
        public bool WikiEnabled { get; set; }

        [JsonProperty("jobs_enabled")]
        public bool JobsEnabled { get; set; }

        [JsonProperty("snippets_enabled")]
        public bool SnippetsEnabled { get; set; }

        [JsonProperty("shared_runners_enabled")]
        public bool SharedRunnersEnabled { get; set; }

        [JsonProperty("lfs_enabled")]
        public bool LFSEnabled { get; set; }

        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonProperty("namespace")]
        public Namespace Namespace { get; set; }

        [JsonProperty("import_status")]
        public string ImportStatus { get; set; }

        [JsonProperty("open_issues_count")]
        public int OpenIssuesCount { get; set; }

        [JsonProperty("public_jobs")]
        public bool PublicJobs { get; set; }

        [JsonProperty("only_allow_merge_if_pipeline_succeeds")]
        public bool OnlyMergeIfPipelineSucceeeds { get; set; }

        [JsonProperty("request_access_enabled")]
        public bool RequestAccessEnabled { get; set; }

        [JsonProperty("only_allow_merge_if_all_discussions_are_resolved")]
        public bool OnlyMergeIfDiscussionsAreResolved { get; set; }

        [JsonProperty("printing_merge_request_link_enabled")]
        public bool PrintingMergeRequestLinkEnabled { get; set; }
    }
}
