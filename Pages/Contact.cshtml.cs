using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;

namespace Portfolio.Pages
{
    public class Contact : PageModel
    {
        public void OnGet() => Page();
        
        [BindProperty] 
        public ContactSubmission ContactSubmission { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            // send email
            return null;
        }
    }
}