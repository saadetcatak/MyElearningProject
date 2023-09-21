namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_feature_rev : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Features", "Image");
        }
    }
}
