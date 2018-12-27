namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSysAidRequestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysAidRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Long(nullable: false),
                        FirstLevel = c.String(),
                        SecondLevel = c.String(),
                        ThirdLevel = c.String(),
                        Status = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysAidRequests");
        }
    }
}
