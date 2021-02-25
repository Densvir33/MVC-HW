namespace University_Manager_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class your_migr_name : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Groups", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "StudentId", c => c.String());
        }
    }
}
