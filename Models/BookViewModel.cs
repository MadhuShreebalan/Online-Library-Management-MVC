using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    [Table("TableBooks")]
    public class BookViewModel
    {
        [Required]
        public int BookId { get;  set; }
        [Display(Name = "Author")]
        [Required]
        public string Author { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Subject")]
        [StringLength(20)]
        public string Subject { get; set; }
 
    }
}