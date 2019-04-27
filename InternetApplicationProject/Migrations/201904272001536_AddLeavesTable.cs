namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeavesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectLeavesTreanees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        TreaneeID = c.Int(nullable: false),
                        IDProject_Id = c.Int(),
                        IDtreanee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.IDProject_Id)
                .ForeignKey("dbo.OurUsers", t => t.IDtreanee_Id)
                .Index(t => t.IDProject_Id)
                .Index(t => t.IDtreanee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectLeavesTreanees", "IDtreanee_Id", "dbo.OurUsers");
            DropForeignKey("dbo.ProjectLeavesTreanees", "IDProject_Id", "dbo.Projects");
            DropIndex("dbo.ProjectLeavesTreanees", new[] { "IDtreanee_Id" });
            DropIndex("dbo.ProjectLeavesTreanees", new[] { "IDProject_Id" });
            DropTable("dbo.ProjectLeavesTreanees");
        }
    }
}
