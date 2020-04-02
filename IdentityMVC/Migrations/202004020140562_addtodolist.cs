namespace IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtodolist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoListItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        isCompleted = c.Boolean(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoListItems", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.ToDoListItems", new[] { "ApplicationUserID" });
            DropTable("dbo.ToDoListItems");
        }
    }
}
