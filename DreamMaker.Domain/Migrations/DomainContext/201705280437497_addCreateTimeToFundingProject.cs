namespace DreamMaker.Domain.Migrations.DomainContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateTimeToFundingProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FundingProjects", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FundingProjects", "CreateTime");
        }
    }
}
