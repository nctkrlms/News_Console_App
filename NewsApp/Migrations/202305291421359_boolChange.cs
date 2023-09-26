namespace NewsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "IsStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IsDelete", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "IsStatus", c => c.Int(nullable: false));
        }
    }
}
