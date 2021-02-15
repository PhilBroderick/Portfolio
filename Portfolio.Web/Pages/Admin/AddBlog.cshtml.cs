using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Web.Pages.Admin
{
    [Authorize]
    public class AddBlog : PageModel
    {
        private readonly IBlogService _blogService;

        [BindProperty]
        public CreateBlogRequest CreateBlogRequest { get; set; }

        public AddBlog(IBlogService blogService, IConfiguration configuration)
        {
            _blogService = blogService;
            FileUploadFunctionUrl = configuration.GetValue<string>("FileUploadFunction");
        }

        public string FileUploadFunctionUrl { get; }
        
        public async Task OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _blogService.CreateNewBlog(CreateBlogRequest))
                return RedirectToPage("/Admin/ManageBlogs");

            return Page();
        }
    }
}