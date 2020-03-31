using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class SignupViewModel
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage = "Email is not valid" )]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(5)]
        public string Department { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public long Phone { get; set; }
    }
}