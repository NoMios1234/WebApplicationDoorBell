namespace CamDoorBellApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class norm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Samples",
                c => new
                {
                    SampleId = c.Int(nullable: false, identity: true),
                    SampleName = c.String(nullable: false),
                    SampleSize = c.Int(nullable: false),
                    SampleLink = c.String(),
                    PlaylistName = c.String(),
                })
                .PrimaryKey(t => t.SampleId)
                .ForeignKey("dbo.Playlists", t => t.PlaylistName)
                .Index(t => t.PlaylistName);
        }
        
        public override void Down()
        {
        }
    }
}
