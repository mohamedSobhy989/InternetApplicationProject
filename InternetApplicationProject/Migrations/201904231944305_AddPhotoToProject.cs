namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "PhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "PhotoPath");
        }
    }
}
