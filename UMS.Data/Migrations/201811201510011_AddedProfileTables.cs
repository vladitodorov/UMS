namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProfileTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileDirections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DirectionName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileDirectorates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Directoratename = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileHeadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfilePositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfilePositions");
            DropTable("dbo.ProfileHeadings");
            DropTable("dbo.ProfileDirectorates");
            DropTable("dbo.ProfileDirections");
        }
    }
}
