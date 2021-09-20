using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
    }
}