namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OurUsers", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OurUsers", "Photo", c => c.Binary());
        }
    }
}
