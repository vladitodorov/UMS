namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false),
                        Direction = c.String(),
                        Directorate = c.String(),
                        Position = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profiles");
        }
    }
}
