namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "BirthDate");
            DropColumn("dbo.Reviews", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Title", c => c.String());
            AddColumn("dbo.Authors", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
