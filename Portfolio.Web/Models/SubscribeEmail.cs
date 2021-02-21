using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class SubscribeEmail
    {
        [Required]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; }
    }
}