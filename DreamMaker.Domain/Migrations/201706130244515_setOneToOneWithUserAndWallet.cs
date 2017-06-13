namespace DreamMaker.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setOneToOneWithUserAndWallet : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserWallets");
            AddColumn("dbo.UserWallets", "UserWalletId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserWallets", "UserWalletId");
            CreateIndex("dbo.UserWallets", "UserWalletId");
            AddForeignKey("dbo.UserWallets", "UserWalletId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.UserWallets", "WalletId");
            DropColumn("dbo.UserWallets", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserWallets", "UserId", c => c.String());
            AddColumn("dbo.UserWallets", "WalletId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UserWallets", "UserWalletId", "dbo.AspNetUsers");
            DropIndex("dbo.UserWallets", new[] { "UserWalletId" });
            DropPrimaryKey("dbo.UserWallets");
            DropColumn("dbo.UserWallets", "UserWalletId");
            AddPrimaryKey("dbo.UserWallets", "WalletId");
        }
    }
}
