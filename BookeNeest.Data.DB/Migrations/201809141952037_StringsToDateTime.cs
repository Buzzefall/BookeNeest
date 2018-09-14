namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringsToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "PublicationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "PublicationDate", c => c.String());
        }
    }
}
