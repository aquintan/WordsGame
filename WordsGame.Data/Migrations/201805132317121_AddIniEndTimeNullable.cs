namespace WordsGame.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIniEndTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rounds", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Rounds", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rounds", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rounds", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
