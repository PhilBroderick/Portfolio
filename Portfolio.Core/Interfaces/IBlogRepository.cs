using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogItem>> GetBlogs(int numOfBlogs);
    }
}