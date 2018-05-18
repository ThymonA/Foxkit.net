namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserClient : ApiClient, IUserClient
    {
        private static readonly Uri UserEndpoint = new Uri(nameof(User).ToLower(), UriKind.Relative);

        public UserClient(
            IApiConnection apiConnection,
            IUserSshKeysClient userSshKeysClient,
            IUserGpgKeysClient userGpgKeysClient)
            : base(apiConnection)
        {
            SshKey = userSshKeysClient;
            GpgKey = userGpgKeysClient;
        }

        public IUserSshKeysClient SshKey { get; }

        public IUserGpgKeysClient GpgKey { get; }

        public User Get(string login)
        {
            login.ArgumentNotNullOrEmptyString(nameof(login));

            return ApiConnection.Get<User>(ApiUrls.User(login)).Result;
        }

        public IReadOnlyList<User> GetAll => ApiConnection.GetAll<User>(ApiUrls.Users()).Result;

        public User Current => ApiConnection.Get<User>(UserEndpoint).Result;

        public Task<User> Update(UserUpdate user)
        {
            user.ArgumentNotNull(nameof(user));

            return ApiConnection.Patch<User>(UserEndpoint, user);
        }
    }
}
