namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSysAidRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysAidRequests", "RequestUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SysAidRequests", "RequestUser");
        }
    }
}
