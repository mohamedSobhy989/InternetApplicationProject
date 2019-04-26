namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "DirectorId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "LeaderId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "TreaneeId", c => c.Int(nullable: false));
            AddColumn("dbo.requestsForTeams", "DirectorId", c => c.Int(nullable: false));
            AddColumn("dbo.requestsForTeams", "States", c => c.Int(nullable: false));
            DropColumn("dbo.Projects", "projectState");
            DropColumn("dbo.requestsForTeams", "role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.requestsForTeams", "role", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "projectState", c => c.Int(nullable: false));
            DropColumn("dbo.requestsForTeams", "States");
            DropColumn("dbo.requestsForTeams", "DirectorId");
            DropColumn("dbo.Projects", "TreaneeId");
            DropColumn("dbo.Projects", "LeaderId");
            DropColumn("dbo.Projects", "DirectorId");
        }
    }
}
