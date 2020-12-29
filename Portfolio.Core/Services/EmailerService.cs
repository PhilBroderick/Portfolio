using System.Threading.Tasks;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceResults;

namespace Portfolio.Core.Services
{
    public class EmailerService : IMessageService
    {
        public async Task<IServiceResult<bool>> SendMessageAsync(string message, string from, string[] recipients)
        {
            return new EmailServiceResult
            {
                IsSuccess = true
            };
        }
    }
}