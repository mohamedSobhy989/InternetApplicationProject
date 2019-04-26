namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInDataBase1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OnProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        project_Name = c.String(nullable: false),
                        customerid = c.Int(nullable: false),
                        projectState = c.Int(nullable: false),
                        projectDelevered = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        description = c.String(nullable: false),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OnProgresses");
        }
    }
}
