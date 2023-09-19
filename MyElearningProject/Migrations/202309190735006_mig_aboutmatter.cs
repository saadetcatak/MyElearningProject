namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aboutmatter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutMatters",
                c => new
                    {
                        AboutMatterID = c.Int(nullable: false, identity: true),
                        Matter = c.String(),
                    })
                .PrimaryKey(t => t.AboutMatterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutMatters");
        }
    }
}
