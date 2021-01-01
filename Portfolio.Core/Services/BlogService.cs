using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        
        public async Task<IEnumerable<BlogItem>> GetMostRecentBlogs(int numOfBlogs)
        {
            return (await _blogRepository.GetBlogs(numOfBlogs)).OrderByDescending(b => b.Created);
        }

        public async Task<BlogItem> CreateNewBlog(CreateBlogRequest createBlogRequest)
        {
            var (title, content) = createBlogRequest;
            
            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(content))
                return null;

            return await _blogRepository.CreateNewBlog(title, content);
        }

        public async Task<BlogItem> GetBlogByTitle(string title)
        {
            return await _blogRepository.GetBlogByTitle(title);
        }
    }
}