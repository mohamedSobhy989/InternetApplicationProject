namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserEmail", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Users", "UserEmail");
        }
    }
}
