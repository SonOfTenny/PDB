namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcalcfieldstoprod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productions", "TotalWaste", c => c.Int(nullable: false));
            AddColumn("dbo.Productions", "TotalProdMins", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productions", "TotalProdMins");
            DropColumn("dbo.Productions", "TotalWaste");
        }
    }
}
