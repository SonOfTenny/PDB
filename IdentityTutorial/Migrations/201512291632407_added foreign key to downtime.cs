namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeytodowntime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Downtimes", "Plant_PlantID", c => c.Int());
            CreateIndex("dbo.Downtimes", "Plant_PlantID");
            AddForeignKey("dbo.Downtimes", "Plant_PlantID", "dbo.Plants", "PlantID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Downtimes", "Plant_PlantID", "dbo.Plants");
            DropIndex("dbo.Downtimes", new[] { "Plant_PlantID" });
            DropColumn("dbo.Downtimes", "Plant_PlantID");
        }
    }
}
