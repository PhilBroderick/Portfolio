namespace Portfolio.Core.Interfaces.Repositories.Queries
{
    public interface ICommandText
    {
        string GetAllBlogs { get; }
        string GetMostRecentBlogs { get; }
        string GetBlogByTitle { get; }
        string GetBlogById { get; }
        string CreateBlog { get; }
        string GetNActiveBlogs { get; }
        string ToggleBlogActiveStats { get; }
        string UpdateBlog { get; }
    }
}