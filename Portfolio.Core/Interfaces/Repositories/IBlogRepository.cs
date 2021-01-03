using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogItem>> GetBlogs(int numOfBlogs);
        Task CreateNewBlog(string title, string content, string description);
        Task<BlogItem> GetBlogByTitle(string title);
    }
}