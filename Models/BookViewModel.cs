using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    [Table("TableBooks")]
    public class BookViewModel
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        [Key]
        public string Id { get; set; }

        public CategoryViewModel CategoryViewModel { get; set; }

    }
}