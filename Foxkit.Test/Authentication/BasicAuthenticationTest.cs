namespace Foxkit.Test.Authentication
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BasicAuthenticationTest
    {
        [TestMethod]
        public void BasicSignIn()
        {
            var config = Configuration.GetConfiguration;

            var credentials = new Credentials(config.Username, config.Password, AuthenticationType.Basic);
            var inMemoryStore = new InMemoryCredentialStore(credentials);
            var gitlabClient = new GitLabClient(new ProductHeaderValue(config.Username), inMemoryStore, config.Url);

            var user = gitlabClient.User.Current;

            Assert.AreNotEqual(user.Username, string.Empty);
        }
    }
}
