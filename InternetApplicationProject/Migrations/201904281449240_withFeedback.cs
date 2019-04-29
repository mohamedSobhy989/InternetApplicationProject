namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withFeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        feedback = c.String(nullable: false),
                        memberId = c.Int(nullable: false),
                        customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.customer_Id, cascadeDelete: true)
                .Index(t => t.customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedBacks", "customer_Id", "dbo.Users");
            DropIndex("dbo.FeedBacks", new[] { "customer_Id" });
            DropTable("dbo.FeedBacks");
        }
    }
}
