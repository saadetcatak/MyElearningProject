﻿namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_instructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "Email", c => c.String());
            AddColumn("dbo.Instructors", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "Password");
            DropColumn("dbo.Instructors", "Email");
        }
    }
}
