namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class ReadOnlyPagedCollection<T> : ReadOnlyCollection<T>, IReadOnlyPagedCollection<T>
    {
        private readonly IApiInfo info;

        private readonly Func<Uri, Task<IApiResponse<IList<T>>>> nextPageFunc;

        public ReadOnlyPagedCollection(IApiResponse<IList<T>> response, Func<Uri, Task<IApiResponse<IList<T>>>> nextPageFunc)
            : base(response != null ? response.Body ?? new List<T>() : new List<T>())
        {
            response.ArgumentNotNull(nameof(response));
            nextPageFunc.ArgumentNotNull(nameof(nextPageFunc));

            this.nextPageFunc = nextPageFunc;

            if (response != null)
            {
                info = response.HttpResponse.ApiInfo;
            }
        }

        public async Task<IReadOnlyPagedCollection<T>> GetNextPage()
        {
            var nextPageUrl = info.GetNextPageUrl();

            if (nextPageUrl == null)
            {
                return null;
            }

            var maybeTask = nextPageFunc(nextPageUrl);

            if (maybeTask == null)
            {
                return null;
            }

            var response = await maybeTask.ConfigureAwait(false);

            return new ReadOnlyPagedCollection<T>(response, nextPageFunc);
        }
    }
}
