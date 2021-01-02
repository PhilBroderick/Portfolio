using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Tests.Core.Services
{
    public class BlogRepositoryMock : IBlogRepository
    {
        public Task<IEnumerable<BlogItem>> GetBlogs(int numOfBlogs)
        {
            return Task.FromResult(GetAllBlogs(numOfBlogs));
        }

        public Task CreateNewBlog(string title, string content)
        {
            return Task.FromResult(new BlogItem
            {
                Id =  Guid.NewGuid(),
                Title = title,
                Content = content,
                Created = DateTime.Now
            });
        }

        public Task<BlogItem> GetBlogByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || title == "invalid title")
                return Task.FromResult<BlogItem>(null);
            return Task.FromResult(new BlogItem
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content = "content",
                Created = DateTime.Now
            });
        }

        private IEnumerable<BlogItem> GetAllBlogs(int numOfBlogs)
        {
            var start = new DateTime(2000, 1, 1);
            var rng = new Random(Guid.NewGuid().GetHashCode());
            var range = (DateTime.Today - start).Days;
            for (int i = 0; i < numOfBlogs; i++)
            {
                yield return new BlogItem
                {
                    Created = start.AddDays(rng.Next(range))
                };
            }
        }
    }
}