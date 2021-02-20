namespace Portfolio.Core.Interfaces.Repositories.Queries
{
    public interface IBlogCommandText
    {
        string GetAllBlogs { get; }
        string GetActiveBlogs { get; }
        string GetBlogByTitle { get; }
        string GetBlogById { get; }
        string CreateBlog { get; }
        string GetNActiveBlogs { get; }
        string ToggleBlogActiveStats { get; }
        string UpdateBlog { get; }
    }
}