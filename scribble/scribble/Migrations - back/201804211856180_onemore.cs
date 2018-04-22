namespace scribble.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onemore : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Drawings", name: "UserId", newName: "DrawingCreator_Id");
            RenameIndex(table: "dbo.Drawings", name: "IX_UserId", newName: "IX_DrawingCreator_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Drawings", name: "IX_DrawingCreator_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Drawings", name: "DrawingCreator_Id", newName: "UserId");
        }
    }
}
