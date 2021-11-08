namespace TechShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20211021 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "icon", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "icon", c => c.Byte(nullable: false));
        }
    }
}
