using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces.Services
{
    public interface IPaginationService
    {
        IEnumerable<T> PaginateResult<T>(IEnumerable<T> list, int currentPage, int pageSize);
    }
}