namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmrph : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plants", "MixRatePerHour", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plants", "MixRatePerHour", c => c.Double(nullable: false));
        }
    }
}
