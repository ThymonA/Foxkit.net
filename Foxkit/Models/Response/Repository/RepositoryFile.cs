namespace Foxkit
{
    using Newtonsoft.Json;

    public class RepositoryFile
    {
        [JsonProperty("file_name")]
        public string Name { get; set; }

        [JsonProperty("file_path")]
        public string Path { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("ref")]
        public string Branch { get; set; }

        [JsonProperty("blob_id")]
        public string BlobId { get; set; }

        [JsonProperty("commit_id")]
        public string CommitId { get; set; }

        [JsonProperty("last_commit_id")]
        public string LastCommitId { get; set; }

        [JsonIgnore]
        public string GitUrl { get; set; }

        [JsonIgnore]
        public string HtmlUrl { get; set; }

        [JsonIgnore]
        public string RawUrl { get; set; }
    }
}
