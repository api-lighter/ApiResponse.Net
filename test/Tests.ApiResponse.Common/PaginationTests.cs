using ApiResponse.Net.Pagination;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ApiResponse.Net.Pagination
{
    [TestFixture]
    public class PaginationTests
    {
        private IQueryable<dynamic> _sampleQueryableCollection;

        [SetUp]
        public void Init()
        {
            _sampleQueryableCollection = Enumerable.Range(0, 100).Select(x => new { Label = $"Item {x}" }).AsQueryable();
        }

        [Test]
        public void TestQueryablePagination()
        {
            var result = _sampleQueryableCollection.ToPages(0, 10, 20);
            Assert.IsTrue(result.HasMore && result.Values.Count() == 20);
        }
    }
}
