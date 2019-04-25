namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserPassword", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "UserPassword");
        }
    }
}
