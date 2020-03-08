namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class File : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "AccountId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Accounts", "AccountId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "AccountId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Accounts", "AccountId");
        }
    }
}
