namespace TechShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2021102102 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "roleId", "dbo.roles");
            DropIndex("dbo.Users", new[] { "roleId" });
            RenameColumn(table: "dbo.Users", name: "roleId", newName: "Role_Id");
            AlterColumn("dbo.Users", "Role_Id", c => c.Int());
            CreateIndex("dbo.Users", "Role_Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.roles");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            AlterColumn("dbo.Users", "Role_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "roleId");
            CreateIndex("dbo.Users", "roleId");
            AddForeignKey("dbo.Users", "roleId", "dbo.roles", "Id", cascadeDelete: true);
        }
    }
}
