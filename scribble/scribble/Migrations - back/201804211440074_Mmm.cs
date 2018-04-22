namespace scribble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mmm : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drawings");
        }
    }
}
