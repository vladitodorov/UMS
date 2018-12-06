namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProfileMenuTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        System = c.String(nullable: false),
                        Role = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfileMenus");
        }
    }
}
