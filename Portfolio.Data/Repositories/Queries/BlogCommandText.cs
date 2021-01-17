using Portfolio.Core.Interfaces.Repositories.Queries;

namespace Portfolio.Data.Repositories.Queries
{
    public class BlogCommandText : ICommandText
    {
        public string GetAllBlogs => "SELECT * from Blog";
        public string GetMostRecentBlogs => "SELECT TOP 10 from Blog order by Created desc";
        public string GetBlogByTitle => "SELECT TOP 1 * from Blog where Title = @Title";
        public string GetBlogById => "SELECT TOP 1 * from Blog where Id = @id";
        public string CreateBlog => "INSERT INTO Blog (Id, Title, Content, Description) VALUES (@Id, @Title, @Content, @Description)";
        public string GetNActiveBlogs => "GetNActiveBlogs";
        public string ToggleBlogActiveStats => "ToggleBlogStatus";
        public string UpdateBlog =>
            "UPDATE Blog SET Title = @Title, Content = @Content, Description = @Description WHERE Id = @Id";
    }
}