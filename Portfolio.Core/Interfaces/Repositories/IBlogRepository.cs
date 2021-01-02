using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogItem>> GetBlogs(int numOfBlogs);
        Task<BlogItem> CreateNewBlog(string title, string content);
        Task<BlogItem> GetBlogByTitle(string title);
    }
}