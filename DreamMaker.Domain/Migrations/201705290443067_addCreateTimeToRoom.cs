namespace DreamMaker.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateTimeToRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "CreateTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "CreateTime");
        }
    }
}
