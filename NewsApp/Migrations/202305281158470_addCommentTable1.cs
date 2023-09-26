namespace NewsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "IsDelete");
        }
    }
}
