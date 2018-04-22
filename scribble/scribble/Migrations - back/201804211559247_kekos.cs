namespace scribble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kekos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drawings", "UserId", c => c.Int());
            CreateIndex("dbo.Drawings", "UserId");
            AddForeignKey("dbo.Drawings", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drawings", "UserId", "dbo.Users");
            DropIndex("dbo.Drawings", new[] { "UserId" });
            DropColumn("dbo.Drawings", "UserId");
        }
    }
}
