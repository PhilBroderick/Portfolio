﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        
        public async Task<IEnumerable<BlogItem>> GetMostRecentBlogs(int numOfBlogs)
        {
            return (await _blogRepository.GetActiveBlogs(numOfBlogs)).OrderByDescending(b => b.Created);
        }

        public async Task<bool> CreateNewBlog(CreateBlogRequest createBlogRequest)
        {
            var (title, content, description, imageUrl) = createBlogRequest;
            
            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(content) ||
                string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(imageUrl))
                return false;

            try
            {
                await _blogRepository.CreateNewBlog(title, content, description, imageUrl);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<BlogItem> GetBlogByTitle(string title)
        {
            return await _blogRepository.GetBlogByTitle(title);
        }

        public async Task<IEnumerable<BlogItem>> GetAllBlogs()
        {
            return (await _blogRepository.GetAll()).OrderByDescending(b => b.Created);
        }

        public async Task ToggleBlogActiveStatus(Guid blogId)
        {
            await _blogRepository.ToggleBlogActiveStatus(blogId);
        }

        public async Task<BlogItem> GetBlogById(Guid id)
        {
            return await _blogRepository.GetBlogById(id);
        }

        public async Task UpdateBlog(UpdateBlogRequest updateBlogRequest)
        {
            await _blogRepository.UpdateBlog(updateBlogRequest.Id, updateBlogRequest.Title, updateBlogRequest.Content,
                updateBlogRequest.Description, updateBlogRequest.ImageUrl);
        }

        public async Task<IEnumerable<BlogItem>> GetActiveBlogs()
        {
            return (await _blogRepository.GetActiveBlogs()).OrderByDescending(b => b.Created);
        }
    }
}