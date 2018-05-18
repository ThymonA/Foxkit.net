namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApiConnection : IApiConnection
    {
        private static User currentUser;

        private readonly IApiPagination pagination;

        public User CurrentUser
        {
            get
            {
                if (currentUser.IsNullOrDefault())
                {
                    try
                    {
                        var user = Get<User>(ApiUrls.User()).Result;
                        currentUser = user;
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return currentUser;
            }
        }

        public IConnection Connection { get; }

        public ApiConnection(IConnection connection)
            : this(connection, new ApiPagination())
        {
        }

        public ApiConnection(IConnection connection, IApiPagination pagination)
        {
            connection.ArgumentNotNull(nameof(connection));
            pagination.ArgumentNotNull(nameof(pagination));

            Connection = connection;
            this.pagination = pagination;
        }

        public Task<T> Get<T>(Uri uri)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            return Get<T>(uri, null);
        }

        public async Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            var response = await Connection.Get<T>(uri, parameters, null).ConfigureAwait(false);

            return response.Body;
        }

        public async Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            accepts.ArgumentNotNull(nameof(accepts));

            var response = await Connection.Get<T>(uri, parameters, accepts).ConfigureAwait(false);

            return response.Body;
        }

        public async Task<string> GetHtml(Uri uri, IDictionary<string, string> parameters)
        {
            uri.ArgumentNotNull(nameof(uri));

            var response = await Connection.GetHtml(uri, parameters).ConfigureAwait(false);

            return response.Body;
        }

        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri)
            where T : class
        {
            return GetAll<T>(uri, ApiOptions.None);
        }

        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IApiOptions options)
            where T : class
        {
            return GetAll<T>(uri, null, null, options);
        }

        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, string accepts)
            where T : class
        {
            return GetAll<T>(uri, null, accepts, ApiOptions.None);
        }

        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters)
            where T : class
        {
            return GetAll<T>(uri, parameters, null, ApiOptions.None);
        }

        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters, IApiOptions options)
            where T : class
        {
            return GetAll<T>(uri, parameters, null, options);
        }

        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            return pagination.GetAllPages(async () => await GetPage<T>(uri, parameters, accepts).ConfigureAwait(false), uri);
        }

        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters, string accepts, IApiOptions options)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            options.ArgumentNotNull(nameof(options));

            parameters = Pagination.Setup(parameters, options);

            return pagination.GetAllPages(async () => await GetPage<T>(uri, parameters, accepts, options).ConfigureAwait(false), uri);
        }

        public Task Post(Uri uri)
        {
            uri.ArgumentNotNull(nameof(uri));

            return Connection.Post(uri);
        }

        public async Task<T> Post<T>(Uri uri)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));

            var response = await Connection.Post<T>(uri).ConfigureAwait(false);

            return response.Body;
        }

        public Task<T> Post<T>(Uri uri, object body)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));

            return Post<T>(uri, body, null, null);
        }

        public Task<T> Post<T>(Uri uri, object body, string accepts)
            where T : class
        {
            return Post<T>(uri, body, accepts, null);
        }

        public async Task<T> Post<T>(Uri uri, object body, string accepts, string contentType)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));

            var response = await Connection.Post<T>(uri, body, accepts, contentType).ConfigureAwait(false);

            return response.Body;
        }

        public async Task<T> Post<T>(Uri uri, object body, string accepts, string contentType, string twoFactorAuthenticationCode)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));
            twoFactorAuthenticationCode.ArgumentNotNullOrEmptyString(nameof(twoFactorAuthenticationCode));

            var response = await Connection.Post<T>(uri, body, accepts, contentType, twoFactorAuthenticationCode).ConfigureAwait(false);

            return response.Body;
        }

        public async Task<T> Post<T>(Uri uri, object body, string accepts, string contentType, TimeSpan timeout)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));

            var response = await Connection.Post<T>(uri, body, accepts, contentType, timeout).ConfigureAwait(false);

            return response.Body;
        }

        public Task Put(Uri uri)
        {
            uri.ArgumentNotNull(nameof(uri));

            return Connection.Put(uri);
        }

        public async Task<T> Put<T>(Uri uri, object body)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));

            var response = await Connection.Put<T>(uri, body).ConfigureAwait(false);

            return response.Body;
        }

        public async Task<T> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));
            twoFactorAuthenticationCode.ArgumentNotNullOrEmptyString(nameof(twoFactorAuthenticationCode));

            var response = await Connection.Put<T>(uri, body, twoFactorAuthenticationCode).ConfigureAwait(false);

            return response.Body;
        }

        public async Task<T> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode, string accepts)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));
            twoFactorAuthenticationCode.ArgumentNotNullOrEmptyString(nameof(twoFactorAuthenticationCode));

            var response = await Connection.Put<T>(uri, body, twoFactorAuthenticationCode, accepts).ConfigureAwait(false);

            return response.Body;
        }

        public Task Patch(Uri uri)
        {
            uri.ArgumentNotNull(nameof(uri));

            return Connection.Patch(uri);
        }

        public Task Patch(Uri uri, string accepts)
        {
            uri.ArgumentNotNull(nameof(uri));
            accepts.ArgumentNotNull(nameof(accepts));

            return Connection.Patch(uri, accepts);
        }

        public async Task<T> Patch<T>(Uri uri, object body)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));

            var response = await Connection.Patch<T>(uri, body).ConfigureAwait(false);

            return response.Body;
        }

        public async Task<T> Patch<T>(Uri uri, object body, string accepts)
            where T : class
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));
            accepts.ArgumentNotNull(nameof(accepts));

            var response = await Connection.Patch<T>(uri, body, accepts).ConfigureAwait(false);

            return response.Body;
        }

        public Task Delete(Uri uri)
        {
            uri.ArgumentNotNull(nameof(uri));

            return Connection.Delete(uri);
        }

        public Task Delete(Uri uri, string twoFactorAuthenticationCode)
        {
            uri.ArgumentNotNull(nameof(uri));
            twoFactorAuthenticationCode.ArgumentNotNullOrEmptyString(nameof(twoFactorAuthenticationCode));

            return Connection.Delete(uri, twoFactorAuthenticationCode);
        }

        public Task Delete(Uri uri, object body)
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));

            return Connection.Delete(uri, body);
        }

        public Task Delete(Uri uri, object body, string accepts)
        {
            uri.ArgumentNotNull(nameof(uri));
            body.ArgumentNotNull(nameof(body));
            accepts.ArgumentNotNull(nameof(accepts));

            return Connection.Delete(uri, body, accepts);
        }

        public async Task<IReadOnlyList<T>> GetQueuedOperation<T>(Uri uri, CancellationToken cancellationToken)
            where T : class
        {
            while (true)
            {
                uri.ArgumentNotNull(nameof(uri));

                var response = await Connection.GetResponse<IReadOnlyList<T>>(uri, cancellationToken).ConfigureAwait(false);

                switch (response.HttpResponse.StatusCode)
                {
                    case HttpStatusCode.Accepted:
                        continue;
                    case HttpStatusCode.NoContent:
                        return new ReadOnlyCollection<T>(new T[] { });
                    case HttpStatusCode.OK:
                        return response.Body;
                }

                throw new ApiException("Queued Operations wrong status codes.", response.HttpResponse.StatusCode);
            }
        }

        public async Task<IReadOnlyPagedCollection<T>> GetPage<T>(
            Uri uri,
            IDictionary<string, string> parameters,
            string accepts)
        {
            uri.ArgumentNotNull(nameof(uri));

            var response = await Connection.Get<IList<T>>(uri, parameters, accepts).ConfigureAwait(false);

            return new ReadOnlyPagedCollection<T>(response, x => Connection.Get<IList<T>>(x, parameters, accepts));
        }

        public async Task<IReadOnlyPagedCollection<T>> GetPage<T>(
            Uri uri,
            IDictionary<string, string> parameters,
            string accepts,
            IApiOptions options)
        {
            uri.ArgumentNotNull(nameof(uri));

            var response = await Connection.Get<IList<T>>(uri, parameters, accepts).ConfigureAwait(false);

            return new ReadOnlyPagedCollection<T>(
                response,
                x =>
                {
                    var shouldContinue = Pagination.ShouldContinue(x, options);

                    return shouldContinue
                        ? Connection.Get<IList<T>>(x, parameters, accepts)
                        : null;
                });
        }
    }
}
