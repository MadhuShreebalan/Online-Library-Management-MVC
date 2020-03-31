using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models
{
    public class CategoryViewModel
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryDescription { get; set; }
    }
}