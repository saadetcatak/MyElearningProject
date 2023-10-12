namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Image");
        }
    }
}
