namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withFeedback2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FeedBacks", "memberId");
            RenameColumn(table: "dbo.FeedBacks", name: "customer_Id", newName: "memberId");
            RenameIndex(table: "dbo.FeedBacks", name: "IX_customer_Id", newName: "IX_memberId");
            AlterColumn("dbo.FeedBacks", "feedback", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedBacks", "feedback", c => c.String(nullable: false));
            RenameIndex(table: "dbo.FeedBacks", name: "IX_memberId", newName: "IX_customer_Id");
            RenameColumn(table: "dbo.FeedBacks", name: "memberId", newName: "customer_Id");
            AddColumn("dbo.FeedBacks", "memberId", c => c.Int(nullable: false));
        }
    }
}
