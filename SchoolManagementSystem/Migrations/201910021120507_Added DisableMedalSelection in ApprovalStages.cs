namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDisableMedalSelectioninApprovalStages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApprovalStages", "DisableMedalSelection", c => c.Boolean(nullable: false));
            DropColumn("dbo.NominationApprovals", "DisableMedalSelection");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NominationApprovals", "DisableMedalSelection", c => c.Boolean(nullable: false));
            DropColumn("dbo.ApprovalStages", "DisableMedalSelection");
        }
    }
}
