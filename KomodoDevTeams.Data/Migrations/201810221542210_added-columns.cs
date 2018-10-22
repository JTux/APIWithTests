namespace KomodoDevTeams.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dev", "DevTeam_TeamId", c => c.Int());
            CreateIndex("dbo.Dev", "DevTeam_TeamId");
            AddForeignKey("dbo.Dev", "DevTeam_TeamId", "dbo.DevTeam", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dev", "DevTeam_TeamId", "dbo.DevTeam");
            DropIndex("dbo.Dev", new[] { "DevTeam_TeamId" });
            DropColumn("dbo.Dev", "DevTeam_TeamId");
        }
    }
}
