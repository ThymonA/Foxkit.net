namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;

    public class ApiPagination : IApiPagination
    {
        public async Task<IReadOnlyList<T>> GetAllPages<T>(Func<Task<IReadOnlyPagedCollection<T>>> getFirstPage, Uri uri)
        {
            getFirstPage.ArgumentNotNull(nameof(getFirstPage));

            try
            {
                var page = await getFirstPage().ConfigureAwait(false);
                var allItems = new List<T>(page);

                while ((page = await page.GetNextPage().ConfigureAwait(false)) != null)
                {
                    allItems.AddRange(page);
                }

                return new ReadOnlyCollection<T>(allItems);
            }
            catch (NotFoundException)
            {
                throw new NotFoundException(string.Format(CultureInfo.InvariantCulture, "{0} was not found.", uri.OriginalString), HttpStatusCode.NotFound);
            }
        }
    }
}
