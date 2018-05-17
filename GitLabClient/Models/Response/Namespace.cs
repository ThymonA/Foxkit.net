﻿namespace Foxkit
{
    using Newtonsoft.Json;

    public class Namespace
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("full_path")]
        public string FullPath { get; set; }

        [JsonProperty("parent_id")]
        public long? ParentId { get; set; }
    }
}
