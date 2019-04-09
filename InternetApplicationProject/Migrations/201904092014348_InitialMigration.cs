namespace InternetApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.projectAssignedDirectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        projectID = c.Int(nullable: false),
                        directoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.directoryID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.projectID, cascadeDelete: true)
                .Index(t => t.projectID)
                .Index(t => t.directoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Photo = c.Binary(),
                        Phone = c.Long(nullable: false),
                        job_description = c.String(nullable: false),
                        role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        project_Name = c.String(nullable: false),
                        customerid = c.Int(nullable: false),
                        projectState = c.Int(nullable: false),
                        projectDelevered = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.customerid, cascadeDelete: true)
                .Index(t => t.customerid);
            
            CreateTable(
                "dbo.projectMembers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        projectid = c.Int(nullable: false),
                        member = c.Int(nullable: false),
                        role = c.Int(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Projects", t => t.projectid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.projectid)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.requestsForTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        role = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                        memberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.memberID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.projectID, cascadeDelete: true)
                .Index(t => t.projectID)
                .Index(t => t.memberID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.teamLeaderProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        teamleaderID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                        ProjectState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.projectID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.teamleaderID, cascadeDelete: true)
                .Index(t => t.teamleaderID)
                .Index(t => t.projectID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.teamLeaderProjects", "teamleaderID", "dbo.Users");
            DropForeignKey("dbo.teamLeaderProjects", "projectID", "dbo.Projects");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.requestsForTeams", "projectID", "dbo.Projects");
            DropForeignKey("dbo.requestsForTeams", "memberID", "dbo.Users");
            DropForeignKey("dbo.projectMembers", "user_Id", "dbo.Users");
            DropForeignKey("dbo.projectMembers", "projectid", "dbo.Projects");
            DropForeignKey("dbo.projectAssignedDirectors", "projectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "customerid", "dbo.Users");
            DropForeignKey("dbo.projectAssignedDirectors", "directoryID", "dbo.Users");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.teamLeaderProjects", new[] { "projectID" });
            DropIndex("dbo.teamLeaderProjects", new[] { "teamleaderID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.requestsForTeams", new[] { "memberID" });
            DropIndex("dbo.requestsForTeams", new[] { "projectID" });
            DropIndex("dbo.projectMembers", new[] { "user_Id" });
            DropIndex("dbo.projectMembers", new[] { "projectid" });
            DropIndex("dbo.Projects", new[] { "customerid" });
            DropIndex("dbo.projectAssignedDirectors", new[] { "directoryID" });
            DropIndex("dbo.projectAssignedDirectors", new[] { "projectID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.teamLeaderProjects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.requestsForTeams");
            DropTable("dbo.projectMembers");
            DropTable("dbo.Projects");
            DropTable("dbo.Users");
            DropTable("dbo.projectAssignedDirectors");
        }
    }
}
