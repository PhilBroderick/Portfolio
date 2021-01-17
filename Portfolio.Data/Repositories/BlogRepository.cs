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
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = await connection.QueryAsync<BlogItem>(_commandText.GetNActiveBlogs, new {numOfBlogs}, 
                commandType: CommandType.StoredProcedure);
            return query;
        }

        public async Task CreateNewBlog(string title, string content, string description)
        {
            var newId = Guid.NewGuid();
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(_commandText.CreateBlog,
                new {Id = newId, Title = title, Content = content, Description = description});
        }

        public async Task<BlogItem> GetBlogByTitle(string title)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = await connection.QueryFirstOrDefaultAsync<BlogItem>(_commandText.GetBlogByTitle,
                new {Title = title});
            return query;
        }

        public async Task<IEnumerable<BlogItem>> GetAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = await connection.QueryAsync<BlogItem>(_commandText.GetAllBlogs);
            return query;
        }

        public async Task ToggleBlogActiveStatus(Guid blogId)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = await connection.ExecuteAsync(_commandText.ToggleBlogActiveStats, new {id = blogId}, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<BlogItem> GetBlogById(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = await connection.QueryFirstOrDefaultAsync<BlogItem>(_commandText.GetBlogById, new { id });
            return query;
        }

        public async Task UpdateBlog(Guid id, string title, string content, string description)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = await connection.ExecuteAsync(_commandText.UpdateBlog, 
                new { Id = id, Title = title, Content = content, Description = description });
        }
    }
}