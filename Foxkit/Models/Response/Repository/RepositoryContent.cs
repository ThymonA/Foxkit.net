namespace Foxkit
{
    using Foxkit.Helpers.Extensions;

    using Newtonsoft.Json;

    public class RepositoryContent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        private string TypeString { get; set; }

        [JsonIgnore]
        public ContentType Type => TypeString.ToEnum(ContentType.Unknown);
    }
}
