using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Pages
{
    public class Blog : PageModel
    {
        private readonly IBlogService _blogService;
        
        public IEnumerable<BlogItem> Blogs { get; set; }
        
        public Blog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        public async Task OnGetAsync()
        {
            Blogs = await  _blogService.GetMostRecentBlogs(10);
        }
    }
}