using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BookViewModel
    {
        [Required]
        public int BookId { get;  set; }

        [Display(Name = "Author")]
        [Required]
        [MaxLength(30)]
        public string Author { get; set; }

        [Display(Name = "Name")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Subject")]
        [MaxLength(50)]
        public string Subject { get; set; }

        
 
    }
}