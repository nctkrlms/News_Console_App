namespace NewsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "NewId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "NewId");
            AddForeignKey("dbo.Comments", "NewId", "dbo.News", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "NewId", "dbo.News");
            DropIndex("dbo.Comments", new[] { "NewId" });
            DropColumn("dbo.Comments", "NewId");
        }
    }
}
