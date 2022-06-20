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
            if (pageSize <= 0)
                throw new ArgumentException();
            if (startPageIndex < 0)
                throw new ArgumentException();
            if (queryResult == null)
                throw new ArgumentNullException(nameof(queryResult));

            this._pageSize = pageSize;
            this._pageIndex = startPageIndex;
            this._sourceQuery = queryResult;
            this._totalPages = (int)(queryResult.Count() / pageSize);
        }

        private PaginationModel(IQueryable<T> queryResult, int pageSize, int startPageIndex, int totalPages)
        {
            if (pageSize <= 0)
                throw new ArgumentException();
            if (startPageIndex < 0)
                throw new ArgumentException();
            if (queryResult == null)
                throw new ArgumentNullException(nameof(queryResult));

            this._pageSize = pageSize;
            this._pageIndex = startPageIndex;
            this._sourceQuery = queryResult;
            this._totalPages = totalPages;
        }

        internal int PageSize => _pageSize;
        internal int PageIndex => _pageIndex;
        internal int TotalPages => _totalPages;
        internal bool HasMore => _pageSize * _pageIndex < _sourceQuery.Count();
        internal IQueryable<T> QueryResult => _sourceQuery;

        internal PaginationModel<T> GetNextPage(int pageNum)
        {
            var skippableItemsCount = pageNum * _pageSize;
            var newModel = new PaginationModel<T>(_sourceQuery.Count() < skippableItemsCount ?
                _sourceQuery :
                _sourceQuery.Skip(pageNum * _pageSize).Take(_pageSize), _pageSize, pageNum, TotalPages);
            return newModel;
        }
    }
}
