using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResponse.Net.Pagination
{
    public static class Extensions
    {
        public static PagedDto<T> ToPages<T>(this IQueryable<T> queryResult, int pageNumber, int pagesCount, int pageSize = 10)
        {
            var model = new PaginationModel<T>(queryResult, pageSize, pageNumber);
            return model.GetNextPage(pageNumber);
        }
    }
}
