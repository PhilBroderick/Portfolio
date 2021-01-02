using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task<IServiceResult<bool>> SendMessageAsync(string message, string from, string[] recipients);
    }
}