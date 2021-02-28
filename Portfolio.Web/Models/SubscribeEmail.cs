using System.ComponentModel.DataAnnotations;
using Portfolio.Configuration;

namespace Portfolio.Models
{
    public class SubscribeEmail
    {
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; }
    }
}