using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResponse.Net.Pagination
{
    public class PagedDto<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PagesCount { get; set; }
        public IQueryable<T> Values { get; set; }
        public bool HasMore { get; set; }
    }
}
