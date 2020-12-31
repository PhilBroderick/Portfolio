using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Portfolio.Core.Interfaces;
using Portfolio.Core.ServiceResults;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Core.Services
{
    public class EmailerService : IMessageService
    {
        private readonly IConfiguration _configuration;
        private readonly SendGridClient _client;
        public EmailerService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new SendGridClient(_configuration.GetValue<string>("SendGridAPIKey"));
        }
        public async Task<IServiceResult<bool>> SendMessageAsync(string message, string from, string[] recipients)
        {
            var fromAddress = new EmailAddress(_configuration.GetValue<string>("ContactFromAddress"), "Website Enquiry");
            var subject = from;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(fromAddress,
                recipients.Select(r => new EmailAddress(r)).ToList(), subject, message, null);

            var response = await _client.SendEmailAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                return new EmailServiceResult
                {
                    IsSuccess = true
                };
            }

            return new EmailServiceResult
            {
                IsSuccess = false
            };
        }
    }
}