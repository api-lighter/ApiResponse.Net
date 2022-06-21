using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResponse.Net.Pagination
{
    public static class Extensions
    {
        public static PagedDto<T> ToPages<T>(this IEnumerable<T> queryResult, int pageNumber, int pagesCount, int pageSize = 10)
        {
            return queryResult.AsQueryable().ToPages(pageNumber, pagesCount, pageSize);
        }

        public static PagedDto<T> ToPages<T>(this IQueryable<T> queryResult, int pageNumber, int pagesCount, int pageSize = 10)
        {
            var model = new PaginationModel<T>(queryResult, pageSize, pageNumber);
            return model.GetNextPage(pageNumber).ToPagedDto();
        }

        internal static PagedDto<T> ToPagedDto<T>(this PaginationModel<T> pagination)
        {
            return new PagedDto<T>
            {
                HasMore = pagination.HasMore,
                PageIndex = pagination.PageIndex,
                PagesCount = pagination.TotalPages,
                PageSize = pagination.PageSize,
                Values = pagination.QueryResult
            };
        }
    }
}
