namespace Foxkit
{
    using Newtonsoft.Json;

    public class User : Account
    {
        [JsonProperty("is_admin")]
        public bool SiteAdmin { get; set; }
    }
}
