﻿namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        ContactInfoID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactInfoes");
        }
    }
}
