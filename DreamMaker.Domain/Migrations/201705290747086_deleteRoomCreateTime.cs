namespace DreamMaker.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteRoomCreateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "CreatorId", c => c.String());
            DropColumn("dbo.Rooms", "CreateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "CreateTime", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "CreatorId", c => c.Int(nullable: false));
        }
    }
}
