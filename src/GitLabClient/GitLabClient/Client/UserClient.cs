namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GitLabClient.Helpers.Extensions;

    public class UserClient : ApiClient, IUsersClient
    {
        private static readonly Uri _userEndpoint = new Uri(nameof(User), UriKind.Relative);

        public UserClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public IUserSshKeysClient SshKey { get; }

        public IUserGpgKeysClient GpgKey { get; }

        public Task<User> Get(string login)
        {
            login.ArgumentNotNullOrEmptyString(nameof(login));

            return ApiConnection.Get<User>(ApiUrls.User(login));
        }

        public Task<IReadOnlyList<User>> GetAll()
        {
            return ApiConnection.Get
        }

        public Task<User> Current()
        {
            return ApiConnection.Get<User>(_userEndpoint);
        }

        public Task<User> Update(UserUpdate user)
        {
            user.ArgumentNotNull(nameof(user));

            return ApiConnection.
        }
    }
}
