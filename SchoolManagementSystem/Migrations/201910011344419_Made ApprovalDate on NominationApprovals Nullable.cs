namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeApprovalDateonNominationApprovalsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NominationApprovals", "ApprovalDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NominationApprovals", "ApprovalDate", c => c.DateTime(nullable: false));
        }
    }
}
