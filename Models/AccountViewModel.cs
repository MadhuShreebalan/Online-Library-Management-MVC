using System.ComponentModel.DataAnnotations;


namespace LibraryManagement.Models
{
    public class AccountViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string EmailId { get; set; }
    }
}