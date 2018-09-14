namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDateForAuthors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Title");
            DropColumn("dbo.Authors", "BirthDate");
        }
    }
}
