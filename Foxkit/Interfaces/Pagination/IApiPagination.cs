namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Used to paginate through API response results.
    /// </summary>
    public interface IApiPagination
    {
        /// <summary>
        /// Paginate a request to asynchronous fetch the results until no more are returned
        /// </summary>
        /// <typeparam name="T">Type of the API resource to get.</typeparam>
        /// <param name="getFirstPage">A function which generates the first request</param>
        /// <param name="uri">The original URI (used only for raising an exception)</param>
        /// <returns>A <see cref="IReadOnlyList{T}"/></returns>
        Task<IReadOnlyList<T>> GetAllPages<T>(Func<Task<IReadOnlyPagedCollection<T>>> getFirstPage, Uri uri);
    }
}
