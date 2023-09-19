namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_map : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        MapID = c.Int(nullable: false, identity: true),
                        LocationURL = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MapID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Maps");
        }
    }
}
