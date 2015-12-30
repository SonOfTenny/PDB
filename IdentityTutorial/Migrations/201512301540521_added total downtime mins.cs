namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtotaldowntimemins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Downtimes", "TotalDownMins", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Downtimes", "TotalDownMins");
        }
    }
}
