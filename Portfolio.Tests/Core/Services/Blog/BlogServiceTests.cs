using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.ServiceModels;
using Portfolio.Core.Services;
using Xunit;

namespace Portfolio.Tests.Core.Services.Blog
{
    public class BlogServiceTests
    {
        private readonly BlogService _blogService;

        public BlogServiceTests()
        {
            IBlogRepository blogRepository = new BlogRepositoryFake();
            _blogService = new BlogService(blogRepository);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public async void GetMostRecentBlogs_ValidNumber_ReturnsNNumberOfBlogs(int n)
        {
            var result = await _blogService.GetMostRecentBlogs(n);

            var blogItems = result as BlogItem[] ?? result.ToArray();
            Assert.Equal(n, blogItems.Length);
            Assert.True(blogItems.All(b => b.IsActive));
        }

        [Fact]
        public async void CreateBlog_ValidCreateBlogRequest_ReturnsTrue()
        {
            var createBlogRequest = new CreateBlogRequest("New blog title", "New blog content", "New description", "New image url");

            var result = await _blogService.CreateNewBlog(createBlogRequest);
            
            Assert.True(result);
        }

        [Fact]
        public async void CreateBlog_InvalidCreateBlogRequest_ReturnsFalse()
        {
            var createBlogRequest = new CreateBlogRequest("", "", "", "");

            var result = await _blogService.CreateNewBlog(createBlogRequest);

            Assert.False(result);
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

        [Fact]
        public async void GetAllBlogs_WhenCalled_ReturnsAllActiveAndInactiveBlogs()
        {
            var result = await _blogService.GetAllBlogs();
            
            Assert.True(result.Any(b => b.IsActive) && result.Any(b => !b.IsActive));
        }

        [Fact]
        public async void GetBlogById_ValidId_ReturnsBlog()
        {
            var validId = Guid.NewGuid();

            var result = await _blogService.GetBlogById(validId);
            
            Assert.Equal(validId, result.Id);
        }

        [Fact]
        public async void GetBlogById_InvalidId_ReturnsNull()
        {
            var invalidId = new Guid();

            var result = await _blogService.GetBlogById(invalidId);

            Assert.Null(result);
        }
    }
}