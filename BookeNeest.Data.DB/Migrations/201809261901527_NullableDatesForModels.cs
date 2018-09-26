namespace BookeNeest.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDatesForModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Authors", "DeathDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "DeathDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
