using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Cache;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Web.Pages.Admin
{
    public class ManageBlogs : PageModel
    {
        public IEnumerable<BlogItem> Blogs { get; set; } 
        private readonly IBlogService _blogService;
        private readonly IMemoryCache _cache;

        public ManageBlogs(IBlogService blogService, IMemoryCache cache)
        {
            _blogService = blogService;
            _cache = cache;
        }
        
        public async Task OnGetAsync()
        {
            Blogs = await _blogService.GetAllBlogs();
        }

        public async Task OnPostToggleAsync(Guid blogId)
        {
            await _blogService.ToggleBlogActiveStatus(blogId);
            Blogs = await _blogService.GetAllBlogs();
            _cache.Remove(CacheKeys.Blogs);
        }
    }
}