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
    }
}