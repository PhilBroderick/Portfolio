using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;

namespace Portfolio.Tests.Core.Services.Auth
{
    public class AuthRepositoryFake : IAuthRepository
    {
        public Task<bool> ValidateUser(string username, string password) =>
            Task.FromResult(username == "test" && password == "test");
    }
}