namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpusNonlifeUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpusNonUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpusUserName = c.String(nullable: false),
                        Agency = c.String(nullable: false),
                        Egn = c.Long(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FullName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateClosed = c.DateTime(),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpusNonUsers");
        }
    }
}
