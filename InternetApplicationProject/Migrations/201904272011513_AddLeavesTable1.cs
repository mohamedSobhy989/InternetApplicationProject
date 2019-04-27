namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeavesTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectLeavesTreanees", "IDProject_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectLeavesTreanees", "IDtreanee_Id", "dbo.OurUsers");
            DropIndex("dbo.ProjectLeavesTreanees", new[] { "IDProject_Id" });
            DropIndex("dbo.ProjectLeavesTreanees", new[] { "IDtreanee_Id" });
            DropColumn("dbo.ProjectLeavesTreanees", "ProjectID");
            DropColumn("dbo.ProjectLeavesTreanees", "TreaneeID");
            RenameColumn(table: "dbo.ProjectLeavesTreanees", name: "IDProject_Id", newName: "ProjectID");
            RenameColumn(table: "dbo.ProjectLeavesTreanees", name: "IDtreanee_Id", newName: "TreaneeID");
            AlterColumn("dbo.ProjectLeavesTreanees", "ProjectID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProjectLeavesTreanees", "TreaneeID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectLeavesTreanees", "ProjectID");
            CreateIndex("dbo.ProjectLeavesTreanees", "TreaneeID");
            AddForeignKey("dbo.ProjectLeavesTreanees", "ProjectID", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectLeavesTreanees", "TreaneeID", "dbo.OurUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectLeavesTreanees", "TreaneeID", "dbo.OurUsers");
            DropForeignKey("dbo.ProjectLeavesTreanees", "ProjectID", "dbo.Projects");
            DropIndex("dbo.ProjectLeavesTreanees", new[] { "TreaneeID" });
            DropIndex("dbo.ProjectLeavesTreanees", new[] { "ProjectID" });
            AlterColumn("dbo.ProjectLeavesTreanees", "TreaneeID", c => c.Int());
            AlterColumn("dbo.ProjectLeavesTreanees", "ProjectID", c => c.Int());
            RenameColumn(table: "dbo.ProjectLeavesTreanees", name: "TreaneeID", newName: "IDtreanee_Id");
            RenameColumn(table: "dbo.ProjectLeavesTreanees", name: "ProjectID", newName: "IDProject_Id");
            AddColumn("dbo.ProjectLeavesTreanees", "TreaneeID", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectLeavesTreanees", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectLeavesTreanees", "IDtreanee_Id");
            CreateIndex("dbo.ProjectLeavesTreanees", "IDProject_Id");
            AddForeignKey("dbo.ProjectLeavesTreanees", "IDtreanee_Id", "dbo.OurUsers", "Id");
            AddForeignKey("dbo.ProjectLeavesTreanees", "IDProject_Id", "dbo.Projects", "Id");
        }
    }
}
