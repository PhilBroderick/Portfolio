using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Tests.Core.Services.Blog
{
    public class BlogRepositoryFake : IBlogRepository
    {
        public Task<IEnumerable<BlogItem>> GetActiveBlogs()
        {
            return Task.FromResult(GetActiveNBlogs(100));
        }

        public Task<IEnumerable<BlogItem>> GetActiveBlogs(int numOfBlogs)
        {
            return Task.FromResult(GetActiveNBlogs(numOfBlogs));
        }

        public Task CreateNewBlog(string title, string content, string description, string imageUrl)
        {
            return Task.FromResult(new BlogItem
            {
                Id =  Guid.NewGuid(),
                Title = title,
                Content = content,
                Created = DateTime.Now,
                Description = description,
                ImageUrl = imageUrl
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

        public async Task<IEnumerable<BlogItem>> GetAll()
        {
            return new List<BlogItem>
            {
                new()
                {
                    IsActive = true
                },
                new()
                {
                    IsActive = false
                }
            };
        }

        public Task ToggleBlogActiveStatus(Guid blogId)
        {
            throw new NotImplementedException();
        }

        public Task<BlogItem> GetBlogById(Guid id)
        {
            if (id == Guid.Empty)
                return Task.FromResult<BlogItem>(null);
            return Task.FromResult(new BlogItem
            {
                Id = id
            });
        }

        public Task UpdateBlog(Guid id, string title, string content, string description, string imageUrl)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<BlogItem> GetActiveNBlogs(int numOfBlogs)
        {
            var start = new DateTime(2000, 1, 1);
            var rng = new Random(Guid.NewGuid().GetHashCode());
            var range = (DateTime.Today - start).Days;
            for (int i = 0; i < numOfBlogs; i++)
            {
                yield return new BlogItem
                {
                    Created = start.AddDays(rng.Next(range)),
                    IsActive = true
                };
            }
        }
    }
}