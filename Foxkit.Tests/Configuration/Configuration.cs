namespace Foxkit.Tests.Configuration
{
    using System;
    using System.Reflection;

    using Newtonsoft.Json;

    public class Configuration
    {
        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("PersonalAccessToken")]
        public string PersonalAccessToken { get; set; }

        [JsonProperty("TestRepository")]
        public string TestRepository { get; set; }

        public static Configuration GetConfiguration()
        {
            return default(Configuration);
        }
    }
}
