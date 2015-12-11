namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeytoidentityuser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        ProductionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ShiftID = c.Int(nullable: false),
                        PlantID = c.Int(nullable: false),
                        ActualMix = c.Int(nullable: false),
                        CrumbWaste = c.Int(nullable: false),
                        Cmp_Waste = c.Int(nullable: false),
                        Manning = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductionID)
                .ForeignKey("dbo.Plants", t => t.PlantID, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.ShiftID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.ShiftID)
                .Index(t => t.PlantID)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productions", "User_Id", "dbo.User");
            DropForeignKey("dbo.Productions", "ShiftID", "dbo.Shifts");
            DropForeignKey("dbo.Productions", "PlantID", "dbo.Plants");
            DropIndex("dbo.Productions", new[] { "User_Id" });
            DropIndex("dbo.Productions", new[] { "PlantID" });
            DropIndex("dbo.Productions", new[] { "ShiftID" });
            DropTable("dbo.Productions");
        }
    }
}
