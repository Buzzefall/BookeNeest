namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDateForAuthors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "BirthDate");
        }
    }
}
