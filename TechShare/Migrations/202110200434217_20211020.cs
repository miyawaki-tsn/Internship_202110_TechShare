namespace TechShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20211020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        password = c.String(),
                        roleId = c.Int(nullable: false),
                        icon = c.Byte(nullable: false),
                        deleteflg = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.roles", t => t.roleId, cascadeDelete: true)
                .Index(t => t.roleId);
            
            CreateTable(
                "dbo.chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.Int(nullable: false),
                        Text = c.String(),
                        File = c.Int(nullable: false),
                        Group_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Group_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        icon = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Group_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Groups_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Groups_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Groups_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCompleted = c.Int(nullable: false),
                        Chat_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.chats", t => t.Chat_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Chat_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tasks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.tasks", "Chat_Id", "dbo.chats");
            DropForeignKey("dbo.Users", "roleId", "dbo.roles");
            DropForeignKey("dbo.chats", "User_Id", "dbo.Users");
            DropForeignKey("dbo.chats", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Group_User", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Group_User", "Groups_Id", "dbo.Groups");
            DropIndex("dbo.tasks", new[] { "User_Id" });
            DropIndex("dbo.tasks", new[] { "Chat_Id" });
            DropIndex("dbo.Group_User", new[] { "Users_Id" });
            DropIndex("dbo.Group_User", new[] { "Groups_Id" });
            DropIndex("dbo.chats", new[] { "User_Id" });
            DropIndex("dbo.chats", new[] { "Group_Id" });
            DropIndex("dbo.Users", new[] { "roleId" });
            DropTable("dbo.tasks");
            DropTable("dbo.Group_User");
            DropTable("dbo.Groups");
            DropTable("dbo.chats");
            DropTable("dbo.Users");
            DropTable("dbo.roles");
        }
    }
}
