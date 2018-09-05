namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "Category");
        }
    }
}
