namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddowntime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Downtimes", "TotalDownMins", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Downtimes", "TotalDownMins", c => c.DateTime(nullable: false));
        }
    }
}
