namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtotalprodminstodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productions", "TotalProdMins", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productions", "TotalProdMins", c => c.Int(nullable: false));
        }
    }
}
