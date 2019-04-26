namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "OurUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OurUsers", newName: "Users");
        }
    }
}
