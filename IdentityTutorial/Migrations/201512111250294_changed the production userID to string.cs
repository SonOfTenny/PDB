namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtheproductionuserIDtostring : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Productions", new[] { "User_Id" });
            DropColumn("dbo.Productions", "UserID");
            RenameColumn(table: "dbo.Productions", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.Productions", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Productions", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Productions", new[] { "UserID" });
            AlterColumn("dbo.Productions", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Productions", name: "UserID", newName: "User_Id");
            AddColumn("dbo.Productions", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Productions", "User_Id");
        }
    }
}
