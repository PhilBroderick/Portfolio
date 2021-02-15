using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Pages
{
    [AllowAnonymous]
    public class Blog : PageModel
    {
        private readonly IBlogService _blogService;

        [BindProperty(SupportsGet = true)] public string Title { get; set; }
        public BlogItem CurrentBlog { get; set; }
        
        public Blog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            CurrentBlog = await _blogService.GetBlogByTitle(Title.Replace('-', ' '));
            if (CurrentBlog is null) return NotFound();

            return Page();
        }
    }
}