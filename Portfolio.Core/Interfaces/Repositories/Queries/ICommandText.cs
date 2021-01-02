namespace Portfolio.Core.Interfaces.Repositories.Queries
{
    public interface ICommandText
    {
        string GetAllBlogs { get; }
        string GetMostRecentBlogs { get; }
        string GetBlogByTitle { get; }
        string CreateBlog { get; }
    }
}