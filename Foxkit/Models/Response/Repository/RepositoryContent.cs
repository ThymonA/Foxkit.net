namespace Foxkit
{
    using Newtonsoft.Json;

    public class RepositoryContent : IRepositoryContent
    {
        [JsonIgnore]
        public RepositoryFile RepositoryFile { get; set; }

        [JsonProperty("id")]
        public string Sha { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonIgnore]
        public ContentType ContentType => (ContentType)(ContentType?)Mode;

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("mode")]
        public int Mode { get; set; }

        [JsonIgnore]
        public string Branch => RepositoryFile.Branch;

        [JsonIgnore]
        public string GitUrl => RepositoryFile.GitUrl;

        [JsonIgnore]
        public string HtmlUrl => RepositoryFile.HtmlUrl;

        [JsonIgnore]
        public string RawUrl => RepositoryFile.RawUrl;

        [JsonIgnore]
        public string Content => RepositoryFile.Content;

        [JsonIgnore]
        public string CommitId => RepositoryFile.CommitId;

        [JsonIgnore]
        public string LastCommitId => RepositoryFile.LastCommitId;

        [JsonIgnore]
        public int Size => RepositoryFile.Size;
    }
}
