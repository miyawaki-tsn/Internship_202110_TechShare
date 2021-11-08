namespace TechShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class katou20211022 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.chats", "Time", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.chats", "Time", c => c.DateTime(nullable: false));
        }
    }
}
