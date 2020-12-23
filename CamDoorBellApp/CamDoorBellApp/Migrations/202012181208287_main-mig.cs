namespace CamDoorBellApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mainmig : DbMigration
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Samples", "Playlist_PlaylistId", "dbo.Playlists");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Samples", new[] { "Playlist_PlaylistId" });
            DropTable("dbo.WirelessConns");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Samples");
            DropTable("dbo.Playlists");
            DropTable("dbo.Cameras");
        }
    }
}
