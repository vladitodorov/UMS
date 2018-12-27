namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSysAidRequest1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysAidRequests", "RequestStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SysAidRequests", "RequestStatus");
        }
    }
}
