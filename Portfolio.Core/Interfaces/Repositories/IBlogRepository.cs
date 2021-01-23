using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogItem>> GetActiveBlogs();
        Task<IEnumerable<BlogItem>> GetActiveBlogs(int numOfBlogs);
        Task CreateNewBlog(string title, string content, string description);
        Task<BlogItem> GetBlogByTitle(string title);
        Task<IEnumerable<BlogItem>> GetAll();
        Task ToggleBlogActiveStatus(Guid blogId);
        Task<BlogItem> GetBlogById(Guid id);
        Task UpdateBlog(Guid id, string title, string content, string description);
    }
}