using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Cache;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Pages
{
    [AllowAnonymous]
    public class Blog : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly IMemoryCache _cache;
        private readonly IPaginationService _paginationService;

        [BindProperty(SupportsGet = true)] public string Title { get; set; }

        [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1; 
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IEnumerable<BlogItem> Blogs { get; set; }
        public BlogItem CurrentBlog { get; set; }
        
        public Blog(IBlogService blogService, IMemoryCache cache, IPaginationService paginationService)
        {
            _blogService = blogService;
            _cache = cache;
            _paginationService = paginationService;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                if (_cache.TryGetValue(CacheKeys.Blogs, out IEnumerable<BlogItem> blogs))
                {
                    Count = blogs.Count();
                    if (_paginationService.IsInvalidCurrentPage(CurrentPage, TotalPages))
                        CurrentPage = 1;
                    Blogs = _paginationService.PaginateList(blogs, CurrentPage, PageSize);
                }
                else
                {
                    var allBlogs = await _blogService.GetActiveBlogs();
                    Count = allBlogs.Count();
                    if (_paginationService.IsInvalidCurrentPage(CurrentPage, TotalPages))
                        CurrentPage = 1;
                    Blogs = _paginationService.PaginateList(allBlogs, CurrentPage, PageSize);
                    
                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromDays(1)
                    };
                    // TODO - when adding functionality to create blogs on frontend - register callback method to refresh cache when new blog added

                    _cache.Set(CacheKeys.Blogs, allBlogs.ToList(), cacheOptions);
                }
            }
            else
            {
                CurrentBlog = await _blogService.GetBlogByTitle(Title.Replace('-', ' '));
                if (CurrentBlog is null) return NotFound();
            }

            Blogs ??= new List<BlogItem>();

            return Page();
        }
    }
}