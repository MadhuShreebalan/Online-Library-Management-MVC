using LibraryManagement.Entity;
using System.Data.Entity;
namespace LibraryManagement.Models
{
    public class LibraryManagementContext : DbContext
    { 
        public LibraryManagementContext() : base("name=LibraryManagementConnection") { }
        public DbSet<CategoryViewModel> Category { get; set; }

    }
}