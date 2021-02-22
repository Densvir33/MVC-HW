namespace University_Manager_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Twomigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Students", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Students", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Students", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Students", "Name");
            CreateIndex("dbo.Students", "ApplicationUser_Id");
        }
    }
}
