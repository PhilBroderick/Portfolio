using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> ValidateUser(string username, string password);
    }
}