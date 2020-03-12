namespace LibraryManagement.Migrations
{
   
    using System.Data.Entity.Migrations;
   

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryManagement.DAL.LibraryManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LibraryManagement.Models.LibraryManagementContext";
        }

        protected override void Seed(LibraryManagement.DAL.LibraryManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
