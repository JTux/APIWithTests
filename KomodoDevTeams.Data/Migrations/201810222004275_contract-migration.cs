namespace KomodoDevTeams.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contractmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contract", "Dev_DevId", "dbo.Dev");
            DropIndex("dbo.Contract", new[] { "Dev_DevId" });
            RenameColumn(table: "dbo.Contract", name: "Dev_DevId", newName: "DevId");
            AddColumn("dbo.Contract", "DevTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contract", "DevId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contract", "DevId");
            AddForeignKey("dbo.Contract", "DevId", "dbo.Dev", "DevId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contract", "DevId", "dbo.Dev");
            DropIndex("dbo.Contract", new[] { "DevId" });
            AlterColumn("dbo.Contract", "DevId", c => c.Int());
            DropColumn("dbo.Contract", "DevTeamId");
            RenameColumn(table: "dbo.Contract", name: "DevId", newName: "Dev_DevId");
            CreateIndex("dbo.Contract", "Dev_DevId");
            AddForeignKey("dbo.Contract", "Dev_DevId", "dbo.Dev", "DevId");
        }
    }
}
