namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withFeedback21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedBacks", "leaderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedBacks", "leaderId");
        }
    }
}
