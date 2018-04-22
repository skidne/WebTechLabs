namespace scribble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uof1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "Country", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
    }
}