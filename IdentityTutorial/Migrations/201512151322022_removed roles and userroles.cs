namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrolesanduserroles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            DropIndex("dbo.User", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            DropColumn("dbo.User", "Role_RoleId");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        RoleId = c.String(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.User", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.UserRoles", "Role_RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.User", "Role_RoleId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles", "RoleId");
            AddForeignKey("dbo.User", "Role_RoleId", "dbo.Roles", "RoleId");
        }
    }
}
