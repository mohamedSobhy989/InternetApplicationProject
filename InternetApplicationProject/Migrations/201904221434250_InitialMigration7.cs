namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "customerid", "dbo.OurUsers");
            DropIndex("dbo.Projects", new[] { "customerid" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Projects", "customerid");
            AddForeignKey("dbo.Projects", "customerid", "dbo.OurUsers", "Id", cascadeDelete: true);
        }
    }
}
