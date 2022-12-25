﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "repassword", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "repassword", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
