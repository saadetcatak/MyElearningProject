namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_relation_watchcourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WatchCourses",
                c => new
                    {
                        WatchCourseID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        VideoNumber = c.Int(nullable: false),
                        VideoUrl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WatchCourseID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchCourses", "CourseID", "dbo.Courses");
            DropIndex("dbo.WatchCourses", new[] { "CourseID" });
            DropTable("dbo.WatchCourses");
        }
    }
}
