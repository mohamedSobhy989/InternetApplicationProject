namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teamLeaderProjects", "directorID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.teamLeaderProjects", "directorID");
        }
    }
}
