using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.Interfaces.Repositories.Queries;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ICommandText _commandText;
        private readonly string _connectionString;

        public BlogRepository(IConfiguration config, ICommandText commandText)
        {
            _commandText = commandText;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<BlogItem>> GetBlogs(int numOfBlogs)
        {
            try
            {
                await using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = await connection.QueryAsync<BlogItem>(_commandText.GetAllBlogs);
                    return query;
                }
            }
            catch (TimeoutException ex)
            {
                throw;
            }
            catch (SqlException ex)
            {
                throw;
            }
            
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