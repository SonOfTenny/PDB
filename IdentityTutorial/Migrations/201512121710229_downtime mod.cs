namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class downtimemod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Downtimes",
                c => new
                    {
                        DowntimeID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        ShiftID = c.Int(nullable: false),
                        DowntimeTypeID = c.Int(nullable: false),
                        Reason = c.String(),
                        Action = c.String(),
                        Date = c.DateTime(nullable: false),
                        Plant_PlantID = c.Int(),
                    })
                .PrimaryKey(t => t.DowntimeID)
                .ForeignKey("dbo.DowntimeTypes", t => t.DowntimeTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Plants", t => t.Plant_PlantID)
                .ForeignKey("dbo.Shifts", t => t.ShiftID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ShiftID)
                .Index(t => t.DowntimeTypeID)
                .Index(t => t.Plant_PlantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Downtimes", "UserID", "dbo.User");
            DropForeignKey("dbo.Downtimes", "ShiftID", "dbo.Shifts");
            DropForeignKey("dbo.Downtimes", "Plant_PlantID", "dbo.Plants");
            DropForeignKey("dbo.Downtimes", "DowntimeTypeID", "dbo.DowntimeTypes");
            DropIndex("dbo.Downtimes", new[] { "Plant_PlantID" });
            DropIndex("dbo.Downtimes", new[] { "DowntimeTypeID" });
            DropIndex("dbo.Downtimes", new[] { "ShiftID" });
            DropIndex("dbo.Downtimes", new[] { "UserID" });
            DropTable("dbo.Downtimes");
        }
    }
}
