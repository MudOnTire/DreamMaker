namespace DreamMaker.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Long(nullable: false, identity: true),
                        RoomName = c.String(),
                        MaxMemberCount = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rooms");
        }
    }
}
