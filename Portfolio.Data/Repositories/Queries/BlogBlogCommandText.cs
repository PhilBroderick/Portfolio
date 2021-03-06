﻿using Portfolio.Core.Interfaces.Repositories.Queries;

namespace Portfolio.Data.Repositories.Queries
{
    public class BlogBlogCommandText : IBlogCommandText
    {
        public string GetAllBlogs => "SELECT * from Blog";
        public string GetActiveBlogs => "SELECT * from Blog where IsActive = 1";
        public string GetBlogByTitle => "SELECT TOP 1 * from Blog where Title = @Title";
        public string GetBlogById => "SELECT TOP 1 * from Blog where Id = @id";
        public string CreateBlog => "INSERT INTO Blog (Id, Title, Content, Description, ImageUrl) VALUES (@Id, @Title, @Content, @Description, @ImageUrl)";
        public string GetNActiveBlogs => "GetNActiveBlogs";
        public string ToggleBlogActiveStats => "ToggleBlogStatus";
        public string UpdateBlog =>
            "UPDATE Blog SET Title = @Title, Content = @Content, Description = @Description, ImageUrl = @ImageUrl WHERE Id = @Id";
    }
}