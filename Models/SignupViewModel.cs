using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class SignupViewModel
    {
        [RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public string EmailId { get; set; }

        public string Password { get; set; }

        [StringLength(5)]
        public string Department { get; set; }

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string Phone { get; set; }
    }
}