using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public async Task<IEnumerable<BlogItem>> GetBlogs(int numOfBlogs)
        {
            // stubbed out data until persistence implemented
            var result = new List<BlogItem>();
            var start = new DateTime(2000, 1, 1);
            var rng = new Random(Guid.NewGuid().GetHashCode());
            var range = (DateTime.Today - start).Days;
            for (int i = 0; i < numOfBlogs; i++)
            {
                result.Add(new BlogItem
                {
                    Created = start.AddDays(rng.Next(range)),
                    Title = $"Title-{i + 1}"
                });
            }

            return result;
        }

        public Task<BlogItem> CreateNewBlog(string title, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task<BlogItem> GetBlogByTitle(string title)
        {
            return Task.FromResult(new BlogItem
            {
                Title = title,
                Created = DateTime.Now,
                Content = "This is a bunch of <b>content</b>"
            });
        }
    }
}