using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Tests.Core.Services
{
    public class BlogRepositoryMock : IBlogRepository
    {
        public Task<IEnumerable<BlogItem>> GetBlogs(int numOfBlogs)
        {
            return Task.FromResult(GetAllBlogs(numOfBlogs));
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