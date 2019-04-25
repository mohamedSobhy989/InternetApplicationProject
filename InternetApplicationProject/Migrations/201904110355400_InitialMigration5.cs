namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OurUsers", "confirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OurUsers", "confirmPassword");
        }
    }
}
