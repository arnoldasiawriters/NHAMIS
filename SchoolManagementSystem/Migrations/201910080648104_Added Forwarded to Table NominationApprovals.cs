namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForwardedtoTableNominationApprovals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NominationApprovals", "Forwarded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NominationApprovals", "Forwarded");
        }
    }
}
