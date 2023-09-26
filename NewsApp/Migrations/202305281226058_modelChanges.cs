namespace NewsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsDelete", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDelete");
            DropColumn("dbo.News", "IsDelete");
        }
    }
}
