namespace GitLabClient
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserSshKeysClient : ApiClient, IUserSshKeysClient
    {
        public UserSshKeysClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<SshKey>> GetAllForCurrent()
        {
            return GetAllForCurrent(ApiOptions.None);
        }

        public Task<IReadOnlyList<SshKey>> GetAllForCurrent(IApiOptions options)
        {
            options.ArgumentNotNull(nameof(options));

            return ApiConnection.GetAll<SshKey>(ApiUrls.SshKeys(), options);
        }

        public Task<SshKey> Get(long id)
        {
            return ApiConnection.Get<SshKey>(ApiUrls.SshKeys(id));
        }

        public Task<SshKey> Create(NewSshKey newGpgKey)
        {
            newGpgKey.ArgumentNotNull(nameof(newGpgKey));

            return ApiConnection.Post<SshKey>(ApiUrls.SshKeys(), newGpgKey);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.SshKeys(id));
        }
    }
}
