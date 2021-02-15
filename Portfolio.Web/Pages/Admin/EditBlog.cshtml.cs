using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Web.Pages.Admin
{
    public class EditBlog : PageModel
    {
        private readonly IBlogService _blogService;
        
        [BindProperty]
        public BlogItem Blog { get; set; }

        public EditBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        public async Task OnGet(Guid id)
        {
            if (id != Guid.Empty)
            {
                Blog = await _blogService.GetBlogById(id);
            }    
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var updateRequest = new UpdateBlogRequest(Blog.Id, Blog.Title, Blog.Content, Blog.Description, Blog.ImageUrl);
            await _blogService.UpdateBlog(updateRequest);
            return RedirectToPage("/Admin/ManageBlogs");
        }
    }
}