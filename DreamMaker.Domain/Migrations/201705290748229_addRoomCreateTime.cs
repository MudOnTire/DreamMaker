namespace DreamMaker.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRoomCreateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "CreateTime");
        }
    }
}
