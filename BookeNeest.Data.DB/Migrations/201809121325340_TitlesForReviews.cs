namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitlesForReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Title");
        }
    }
}
