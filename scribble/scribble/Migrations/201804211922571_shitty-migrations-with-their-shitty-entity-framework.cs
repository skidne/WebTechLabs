namespace scribble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shittymigrationswiththeirshittyentityframework : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drawings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        DrawingCreator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.DrawingCreator_Id)
                .Index(t => t.DrawingCreator_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drawings", "DrawingCreator_Id", "dbo.Users");
            DropIndex("dbo.Drawings", new[] { "DrawingCreator_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Drawings");
        }
    }
}
