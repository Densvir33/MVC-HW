namespace University_Manager_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class your_migr1_name : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "Name", c => c.String());
        }
    }
}
