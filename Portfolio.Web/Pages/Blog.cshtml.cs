using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Cache;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Pages
{
    public class Blog : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly IMemoryCache _cache;

        public IEnumerable<BlogItem> Blogs { get; set; }
        public BlogItem CurrentBlog { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }
        
        public Blog(IBlogService blogService, IMemoryCache cache)
        {
            _blogService = blogService;
            _cache = cache;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                if (_cache.TryGetValue(CacheKeys.Blogs, out List<BlogItem> blogs))
                {
                    Blogs = blogs;
                }
                else
                {
                    Blogs = await _blogService.GetMostRecentBlogs(10);

                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromDays(1)
                    };
                    // TODO - when adding functionality to create blogs on frontend - register callback method to refresh cache when new blog added
                    //cacheOptions.RegisterPostEvictionCallback(MyCallback, this);

                    _cache.Set(CacheKeys.Blogs, Blogs.ToList(), cacheOptions);
                }
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