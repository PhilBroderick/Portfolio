using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces
{
    public interface IMessageService
    {
        Task<IServiceResult<bool>> SendMessageAsync(string message, string from, string[] recipients);
    }
}