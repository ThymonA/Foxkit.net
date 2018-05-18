namespace Foxkit.Test
{
    using System;
    using System.Configuration;

    public class Configuration
    {
        public static Configuration GetConfiguration => new Configuration();

        public Configuration()
        {
            var config = GetConfig();

            Url = config[nameof(Url)].Value;
            Username = config[nameof(Username)].Value;
            Password = config[nameof(Password)].Value;
            PersonalAccessToken = config[nameof(PersonalAccessToken)].Value;
        }

        public string Url { get; }

        public string Username { get; }

        public string Password { get; }

        public string PersonalAccessToken { get; }

        private static KeyValueConfigurationCollection GetConfig()
        {
            var assemblyInfo = typeof(Configuration).Assembly.ManifestModule;
            var path = assemblyInfo.FullyQualifiedName;

            if (path.EndsWith(assemblyInfo.Name))
            {
                path = path.Substring(0, path.IndexOf(assemblyInfo.Name, StringComparison.Ordinal));
                path += "Configuration\\configuration.config";
            }

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };

            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None).AppSettings.Settings;
        }
    }
}
