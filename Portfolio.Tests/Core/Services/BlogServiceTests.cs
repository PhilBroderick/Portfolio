using System;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceModels;
using Portfolio.Core.Services;
using Xunit;

namespace Portfolio.Tests.Core.Services
{
    public class BlogServiceTests
    {
        private readonly BlogService _blogService;

        public BlogServiceTests()
        {
            IBlogRepository blogRepository = new BlogRepositoryMock();
            _blogService = new BlogService(blogRepository);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public async void GetMostRecentBlogs_ValidNumber_ReturnsNNumberOfBlogs(int n)
        {
            var result = await _blogService.GetMostRecentBlogs(n);

            Assert.Equal(n, result.Count());
        }

        [Fact]
        public async void CreateBlog_ValidCreateBlogRequest_ReturnsNewBlogItem()
        {
            var createBlogRequest = new CreateBlogRequest("New blog title", "New blog content");

            var result = await _blogService.CreateNewBlog(createBlogRequest);
            
            Assert.Equal(createBlogRequest.Title, result.Title);
            Assert.Equal(DateTime.Now.Date, result.Created.Date);
        }

        [Fact]
        public async void CreateBlog_InvalidCreateBlogRequest_ReturnsNull()
        {
            var createBlogRequest = new CreateBlogRequest("", "");

            var result = await _blogService.CreateNewBlog(createBlogRequest);

            Assert.Null(result);
        }

        [Fact]
        public async void GetBlogByTitle_ValidTitle_ReturnsBlogItem()
        {
            const string title = "Valid Title";

            var result = await _blogService.GetBlogByTitle(title);
            
            Assert.Equal(title, result.Title);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void GetBlogByTitle_NullOrEmptyTitle_ReturnsNull(string title)
        {
            var result = await _blogService.GetBlogByTitle(title);

            Assert.Null(result);
        }

        [Fact]
        public async void GetBlogByTitle_InvalidTitle_ReturnsNull()
        {
            const string invalidTitle = "invalid title";

            var result = await _blogService.GetBlogByTitle(invalidTitle);

            Assert.Null(result);
        }
    }
}