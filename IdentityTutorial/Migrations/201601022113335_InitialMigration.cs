namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Downtimes", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Downtimes", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Downtimes", "TotalDownMins", c => c.Double(nullable: false));
            AddColumn("dbo.Productions", "TotalWaste", c => c.Int(nullable: false));
            AddColumn("dbo.Productions", "TotalProdMins", c => c.Double(nullable: false));
            AlterColumn("dbo.Plants", "MixRatePerHour", c => c.Double());
            DropColumn("dbo.Downtimes", "duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Downtimes", "duration", c => c.Int(nullable: false));
            AlterColumn("dbo.Plants", "MixRatePerHour", c => c.Int(nullable: false));
            DropColumn("dbo.Productions", "TotalProdMins");
            DropColumn("dbo.Productions", "TotalWaste");
            DropColumn("dbo.Downtimes", "TotalDownMins");
            DropColumn("dbo.Downtimes", "EndTime");
            DropColumn("dbo.Downtimes", "StartTime");
        }
    }
}
