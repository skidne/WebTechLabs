namespace scribble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uof : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Country", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Gender", c => c.String());
            AlterColumn("dbo.Users", "Country", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
