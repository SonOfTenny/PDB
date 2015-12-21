namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removeddurationandaddedstartandendtimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Downtimes", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Downtimes", "EndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Downtimes", "duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Downtimes", "duration", c => c.Int(nullable: false));
            DropColumn("dbo.Downtimes", "EndTime");
            DropColumn("dbo.Downtimes", "StartTime");
        }
    }
}
