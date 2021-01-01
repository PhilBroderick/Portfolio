using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Pages
{
    public class Blog : PageModel
    {
        private readonly IBlogService _blogService;
        
        public IEnumerable<BlogItem> Blogs { get; set; }
        public BlogItem CurrentBlog { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }
        
        public Blog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                Blogs = await _blogService.GetMostRecentBlogs(10);
            }
            else
            {
                CurrentBlog = await _blogService.GetBlogByTitle(Title.Replace('-', ' '));
                if (CurrentBlog is null) return NotFound();
            }

            return Page();
        }
    }
}