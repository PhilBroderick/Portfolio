using System;

namespace Portfolio.Core.ServiceModels
{
    public record UpdateBlogRequest(Guid Id, string Title, string Content, string Description, string ImageUrl);
}