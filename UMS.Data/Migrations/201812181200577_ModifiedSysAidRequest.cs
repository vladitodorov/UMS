namespace UMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedSysAidRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysAidRequests", "InsertTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.SysAidRequests", "CloseTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.SysAidRequests", "UserFirstName", c => c.String());
            AddColumn("dbo.SysAidRequests", "UserSurName", c => c.String());
            AddColumn("dbo.SysAidRequests", "UserFamilyName", c => c.String());
            AddColumn("dbo.SysAidRequests", "UserEGN", c => c.String());
            AddColumn("dbo.SysAidRequests", "UserAddress", c => c.String());
            AddColumn("dbo.SysAidRequests", "HermesId", c => c.String());
            AddColumn("dbo.SysAidRequests", "Email", c => c.String());
            AddColumn("dbo.SysAidRequests", "AdAccount", c => c.String());
            AddColumn("dbo.SysAidRequests", "Napravlenie", c => c.String());
            AddColumn("dbo.SysAidRequests", "Upravlenie", c => c.String());
            AddColumn("dbo.SysAidRequests", "Direction", c => c.String());
            AddColumn("dbo.SysAidRequests", "Otdel", c => c.String());
            AddColumn("dbo.SysAidRequests", "Position", c => c.String());
            AlterColumn("dbo.SysAidRequests", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SysAidRequests", "Status", c => c.Long(nullable: false));
            DropColumn("dbo.SysAidRequests", "Position");
            DropColumn("dbo.SysAidRequests", "Otdel");
            DropColumn("dbo.SysAidRequests", "Direction");
            DropColumn("dbo.SysAidRequests", "Upravlenie");
            DropColumn("dbo.SysAidRequests", "Napravlenie");
            DropColumn("dbo.SysAidRequests", "AdAccount");
            DropColumn("dbo.SysAidRequests", "Email");
            DropColumn("dbo.SysAidRequests", "HermesId");
            DropColumn("dbo.SysAidRequests", "UserAddress");
            DropColumn("dbo.SysAidRequests", "UserEGN");
            DropColumn("dbo.SysAidRequests", "UserFamilyName");
            DropColumn("dbo.SysAidRequests", "UserSurName");
            DropColumn("dbo.SysAidRequests", "UserFirstName");
            DropColumn("dbo.SysAidRequests", "CloseTime");
            DropColumn("dbo.SysAidRequests", "InsertTime");
        }
    }
}
