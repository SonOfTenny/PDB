namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingproductionplantshiftanddowntimetypetables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DowntimeTypes",
                c => new
                    {
                        DowntimeTypeID = c.Int(nullable: false, identity: true),
                        PlantID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DowntimeTypeID)
                .ForeignKey("dbo.Plants", t => t.PlantID, cascadeDelete: true)
                .Index(t => t.PlantID);
            
            CreateTable(
                "dbo.Plants",
                c => new
                    {
                        PlantID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MixRatePerHour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlantID);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ShiftID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DowntimeTypes", "PlantID", "dbo.Plants");
            DropIndex("dbo.DowntimeTypes", new[] { "PlantID" });
            DropTable("dbo.Shifts");
            DropTable("dbo.Plants");
            DropTable("dbo.DowntimeTypes");
        }
    }
}
