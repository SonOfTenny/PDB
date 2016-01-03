namespace IdentityTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddtype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DTypes",
                c => new
                    {
                        DTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.DTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DTypes");
        }
    }
}
