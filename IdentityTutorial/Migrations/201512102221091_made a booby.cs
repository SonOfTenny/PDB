namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeabooby : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "Role");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Role", newName: "Roles");
        }
    }
}
