namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_category_rev : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryImage");
        }
    }
}
