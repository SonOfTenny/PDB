namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Downtimes", "duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Downtimes", "duration");
        }
    }
}
