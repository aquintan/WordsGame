namespace WordsGame.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinishAndIniEndTimeToRound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "IsFinished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rounds", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rounds", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rounds", "EndTime");
            DropColumn("dbo.Rounds", "StartTime");
            DropColumn("dbo.Rounds", "IsFinished");
        }
    }
}
