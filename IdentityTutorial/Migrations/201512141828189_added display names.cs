namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddisplaynames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productions", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Productions", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productions", "EndTime");
            DropColumn("dbo.Productions", "StartTime");
        }
    }
}
