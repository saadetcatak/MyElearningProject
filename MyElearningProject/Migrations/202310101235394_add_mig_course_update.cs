namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_course_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Quota", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Quota");
        }
    }
}
