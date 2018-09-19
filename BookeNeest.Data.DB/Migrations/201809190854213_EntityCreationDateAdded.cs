namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityCreationDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tags", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "CreationDate");
            DropColumn("dbo.Reviews", "CreationDate");
            DropColumn("dbo.Genres", "CreationDate");
            DropColumn("dbo.Books", "CreationDate");
            DropColumn("dbo.Authors", "CreationDate");
        }
    }
}
