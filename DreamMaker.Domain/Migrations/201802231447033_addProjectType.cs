namespace DreamMaker.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProjectType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FundingProjects", "ProjectType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FundingProjects", "ProjectType");
        }
    }
}
