using System;
using System.Linq;

namespace ApiResponse.Net.Pagination
{
    internal class PaginationModel<T>
    {
        private readonly int _pageSize;
        private readonly int _pageIndex;
        private readonly int _totalPages;
        private readonly IQueryable<T> _sourceQuery;

        public PaginationModel(IQueryable<T> queryResult, int pageSize, int startPageIndex)
        {
            this._pageSize = pageSize;
            this._pageIndex = startPageIndex;
            this._sourceQuery = queryResult;
            this._totalPages = (int)(queryResult.Count() / pageSize);
        }

        public PagedDto<T> GetNextPage(int pageNum)
        {
            var skippableItemsCount = pageNum * _pageSize;
            return _sourceQuery.Count() < skippableItemsCount ? 
                _sourceQuery.ToPages(this._pageIndex, this._totalPages, this._pageSize) : 
                _sourceQuery.Skip(pageNum * _pageSize).Take(_pageSize).ToPages(pageNum, this._totalPages, _pageSize);
        }
    }
}
