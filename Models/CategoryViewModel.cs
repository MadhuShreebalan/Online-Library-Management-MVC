using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    [Table("TableCategory")]
    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        public int CategoryName { get; set; }
        public int CategoryDescription { get; set; }
    }
}