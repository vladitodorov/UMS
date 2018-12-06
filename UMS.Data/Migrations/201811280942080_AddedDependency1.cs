namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDependency1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileProfileMenus",
                c => new
                    {
                        Profile_Id = c.Int(nullable: false),
                        ProfileMenu_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_Id, t.ProfileMenu_Id })
                .ForeignKey("dbo.Profiles", t => t.Profile_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProfileMenus", t => t.ProfileMenu_Id, cascadeDelete: true)
                .Index(t => t.Profile_Id)
                .Index(t => t.ProfileMenu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileProfileMenus", "ProfileMenu_Id", "dbo.ProfileMenus");
            DropForeignKey("dbo.ProfileProfileMenus", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.ProfileProfileMenus", new[] { "ProfileMenu_Id" });
            DropIndex("dbo.ProfileProfileMenus", new[] { "Profile_Id" });
            DropTable("dbo.ProfileProfileMenus");
        }
    }
}
