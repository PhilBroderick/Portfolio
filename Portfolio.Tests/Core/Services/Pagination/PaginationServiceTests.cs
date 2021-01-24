using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.Services;
using Xunit;

namespace Portfolio.Tests.Core.Services.Pagination
{
    public class PaginationServiceTests
    {
        private readonly PaginationService _paginationService = new PaginationService();

        private readonly List<int> _listToPaginate =  new List<int>
        {
            1,2,3,4,5,6,7,8,9,10
        };

        [Fact]
        public void PaginateList_ValidCurrentPageAndPageSize_ReturnsCorrectlyPaginatedList()
        {
            var result = _paginationService.PaginateList(_listToPaginate, 1, 5);
            
            Assert.Equal(5, result.Count());
            Assert.Equal(_listToPaginate[4], result.Last());
        }

        [Fact]
        public void PaginateList_EmptyList_ReturnsEmptyList()
        {
            var result = _paginationService.PaginateList(System.Array.Empty<int>(), 1, 5);
            
            Assert.Empty(result);
        }

        [Fact]
        public void PaginateList_InvalidCurrentPageOrPageSize_ReturnsEmptyList()
        {
            var result = _paginationService.PaginateList(_listToPaginate, 3, 10);
            
            Assert.Empty(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        public void IsInvalidCurrentPage_InvalidCurrentPage_ReturnsTrue(int currentPage)
        {
            var result = _paginationService.IsInvalidCurrentPage(currentPage, 1);
            
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void IsInvalidCurrentPage_ValidCurrentPage_ReturnsFalse(int currentPage)
        {
            var result = _paginationService.IsInvalidCurrentPage(currentPage, 2);
            
            Assert.False(result);
        }
    }
}