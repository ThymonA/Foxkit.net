namespace GitLabClient
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReadOnlyPagedCollection<T> : IReadOnlyList<T>
    {
        /// <summary>
        /// Returns the next page of items.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{T}"/></returns>
        Task<IReadOnlyPagedCollection<T>> GetNextPage();
    }
}
