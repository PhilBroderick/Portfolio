using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogItem>> GetMostRecentBlogs(int numOfBlogs);

        Task<bool> CreateNewBlog(CreateBlogRequest createBlogRequest);

        Task<BlogItem> GetBlogByTitle(string title);
        Task<IEnumerable<BlogItem>> GetAllBlogs();
        Task ToggleBlogActiveStatus(Guid blogId);
        Task<BlogItem> GetBlogById(Guid id);
        Task UpdateBlog(UpdateBlogRequest updateBlogRequest);
    }
}