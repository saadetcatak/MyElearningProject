namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_rev_about : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Description2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Description2");
        }
    }
}
