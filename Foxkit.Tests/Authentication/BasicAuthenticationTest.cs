namespace Foxkit.Tests.Authentication
{
    using System.Reflection;

    using Foxkit.Tests.Configuration;

    using Xunit;

    public class BasicAuthenticationTest
    {
        [Fact]
        public void GetUserInformation()
        {
            var assembly = typeof(Configuration).GetTypeInfo().Assembly.FullName;

            Assert.Equal(string.Empty, assembly);
        }
    }
}
