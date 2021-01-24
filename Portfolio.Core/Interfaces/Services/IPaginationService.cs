using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces.Services
{
    public interface IPaginationService
    {
        IEnumerable<T> PaginateList<T>(IEnumerable<T> list, int currentPage, int pageSize);
        bool IsInvalidCurrentPage(int currentPage, int totalPages);
    }
}