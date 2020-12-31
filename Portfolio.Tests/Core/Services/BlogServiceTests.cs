using System.Linq;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces;
using Portfolio.Core.Services;
using Xunit;

namespace Portfolio.Tests.Core.Services
{
    public class BlogServiceTests
    {
        private readonly BlogService _blogService;
        private readonly IBlogRepository _blogRepository;
        
        public BlogServiceTests()
        {
            _blogRepository = new BlogRepositoryMock();
            _blogService = new BlogService(_blogRepository);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public async Task GetMostRecentBlogs_ValidNumber_ReturnsNNumberOfBlogs(int n)
        {
            var result = await _blogService.GetMostRecentBlogs(n);

            Assert.Equal(n, result.Count());
        }
    }
}