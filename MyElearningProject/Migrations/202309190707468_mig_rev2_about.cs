namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_rev2_about : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "Description2");
            DropColumn("dbo.Abouts", "Matter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "Matter", c => c.String());
            AddColumn("dbo.Abouts", "Description2", c => c.String());
        }
    }
}
