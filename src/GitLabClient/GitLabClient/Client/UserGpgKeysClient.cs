namespace Foxkit
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserGpgKeysClient : ApiClient, IUserGpgKeysClient
    {
        public UserGpgKeysClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<GpgKey>> GetAllForCurrent()
        {
            return GetAllForCurrent(ApiOptions.None);
        }

        public Task<IReadOnlyList<GpgKey>> GetAllForCurrent(IApiOptions options)
        {
            options.ArgumentNotNull(nameof(options));

            return ApiConnection.GetAll<GpgKey>(ApiUrls.GpgKeys(), options);
        }

        public Task<GpgKey> Get(long id)
        {
            return ApiConnection.Get<GpgKey>(ApiUrls.GpgKeys(id));
        }

        public Task<GpgKey> Create(NewGpgKey newGpgKey)
        {
            newGpgKey.ArgumentNotNull(nameof(newGpgKey));

            return ApiConnection.Post<GpgKey>(ApiUrls.GpgKeys(), newGpgKey);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.GpgKeys(id));
        }
    }
}
