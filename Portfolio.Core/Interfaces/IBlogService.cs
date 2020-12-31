﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogItem>> GetMostRecentBlogs(int numOfBlogs);
    }
}