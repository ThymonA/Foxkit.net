namespace Foxkit.Tests.Authentication
{
    using System;
    using System.IO;
    using System.Reflection;

    using Foxkit.Tests.Configuration;

    using Xunit;

    public class BasicAuthenticationTests
    {
        [Fact]
        public void GetUserInformation()
        {
            var assembly = typeof(Configuration).GetTypeInfo().Assembly;
            var manifest = assembly.ManifestModule;
            var name = manifest.Name;
            var path = manifest.FullyQualifiedName;

            if (path.EndsWith(name))
            {
                path = path.Substring(0, path.LastIndexOf(name, StringComparison.Ordinal));
            }

            var configLocation = $"{path}{nameof(Configuration)}\\{nameof(Configuration).ToLower()}.json";

            //if (File.Exists(configLocation))
            //{
            //    configLocation = true.ToString();
            //}

            Assert.Equal(string.Empty, assembly.FullName);
        }
    }
}
