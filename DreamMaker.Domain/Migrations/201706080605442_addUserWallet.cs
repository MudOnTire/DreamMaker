namespace DreamMaker.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserWallet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserWallets",
                c => new
                    {
                        WalletId = c.Int(nullable: false, identity: true),
                        CurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlipayAccount = c.String(),
                        WeChatAccount = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.WalletId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserWallets");
        }
    }
}
