namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaderTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teamLeaderProjects", "memberOne", c => c.Int(nullable: false));
            AddColumn("dbo.teamLeaderProjects", "memberTwo", c => c.Int(nullable: false));
            AddColumn("dbo.teamLeaderProjects", "memberThree", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.teamLeaderProjects", "memberThree");
            DropColumn("dbo.teamLeaderProjects", "memberTwo");
            DropColumn("dbo.teamLeaderProjects", "memberOne");
        }
    }
}
