namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OurUsers", "PhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OurUsers", "PhotoPath");
        }
    }
}
