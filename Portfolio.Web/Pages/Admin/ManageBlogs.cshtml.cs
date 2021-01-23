using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IBlogService _blogService;
        private readonly IMemoryCache _cache;
        private readonly IPaginationService _paginationService;
        
        [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1; 
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IEnumerable<BlogItem> Blogs { get; set; } 
        

        public ManageBlogs(IBlogService blogService, IMemoryCache cache, IPaginationService paginationService)
        {
            _blogService = blogService;
            _cache = cache;
            _paginationService = paginationService;
        }
        
        public async Task OnGetAsync()
        {
            var allBlogs = await _blogService.GetAllBlogs();
            Blogs = _paginationService.PaginateResult(allBlogs, CurrentPage, PageSize);
            Count = allBlogs.Count();
        }

        public async Task OnPostToggleAsync(Guid blogId)
        {
            await _blogService.ToggleBlogActiveStatus(blogId);
            var allBlogs = await _blogService.GetAllBlogs();
            Blogs = _paginationService.PaginateResult(allBlogs, CurrentPage, PageSize);
            Count = allBlogs.Count();
            _cache.Remove(CacheKeys.Blogs);
        }
    }
}