using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Portfolio.Configuration;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Models;

namespace Portfolio.Pages
{
    [AllowAnonymous]
    public class Contact : PageModel
    {
        private readonly IMessageService _messageService;
        private readonly IConfiguration _configuration;

        public Contact(IMessageService messageService, IConfiguration configuration)
        {
            _messageService = messageService;
            _configuration = configuration;
        }
        
        public void OnGet() => Page();
        
        [BindProperty] 
        public ContactSubmission ContactSubmission { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var contactRecipientsOptions = new ContactRecipientsOptions
            {
                ContactRecipients = _configuration.GetValue<string>(ContactRecipientsOptions.ContactRecipientsName)
            };

            var result = await _messageService.SendMessageAsync(ContactSubmission.Message, ContactSubmission.Email,
                contactRecipientsOptions.ContactRecipients.Split(","));
            
            if (result.IsSuccess)
            {
                ContactSubmission = new ContactSubmission();
                ModelState.Clear();
                ViewData["AlertType"] = "success";
                ViewData["AlertMessage"] = "Your message has been sent - I'll be in touch soon!";
                return Page();
            }
            ViewData["AlertType"] = "danger";
            ViewData["AlertMessage"] = "Uh oh! Not sure what happened there. Please try again";
            return Page();
        }
    }
}