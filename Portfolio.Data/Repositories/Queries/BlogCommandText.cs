using Portfolio.Core.Interfaces.Repositories.Queries;

namespace Portfolio.Data.Repositories.Queries
{
    public class BlogCommandText : ICommandText
    {
        public string GetAllBlogs => "SELECT * from Blog";
        public string GetMostRecentBlogs => "SELECT TOP 10 from Blog order by Created desc";
        public string CreateBlog { get; }
    }
}