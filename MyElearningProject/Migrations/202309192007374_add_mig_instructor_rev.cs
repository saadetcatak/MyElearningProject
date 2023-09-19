namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_instructor_rev : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "Title", c => c.String());
            AddColumn("dbo.Instructors", "CoverImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "CoverImage");
            DropColumn("dbo.Instructors", "Title");
        }
    }
}
