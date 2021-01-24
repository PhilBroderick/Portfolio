using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Services;

namespace Portfolio.Core.Services
{
    public class PaginationService : IPaginationService
    {
        public IEnumerable<T> PaginateList<T>(IEnumerable<T> list, int currentPage, int pageSize)
        {
            return list.Skip((currentPage - 1) * pageSize).Take(pageSize);
        }

        public bool IsInvalidCurrentPage(int currentPage, int totalPages) =>
            currentPage > totalPages || currentPage <= 0;
    }
}