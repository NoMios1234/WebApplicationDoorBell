namespace WebApplicationDoorBell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Samples", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samples", "Duration", c => c.Double(nullable: false));
        }
    }
}
