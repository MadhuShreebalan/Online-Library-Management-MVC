 using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [Range(7, 16)]
        public string Password { get; set; }
    }
}