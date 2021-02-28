using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;
using Portfolio.Models.Content;

namespace Portfolio.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<BlogItem> MostRecentBlogs { get; set; }
        public static IndexContent Content;	
        
        public IndexModel(IBlogService blogService, ILogger<IndexModel> logger)
        {
            _blogService = blogService;
            _logger = logger;
            Content = new IndexContent(
            "Hi, I'm Phil Broderick",	
            "Full stack developer specialising in Azure and DevOps practices");
        }
        
        public async Task OnGetAsync()
        {
            MostRecentBlogs = await _blogService.GetMostRecentBlogs(5);
        }
    }
}