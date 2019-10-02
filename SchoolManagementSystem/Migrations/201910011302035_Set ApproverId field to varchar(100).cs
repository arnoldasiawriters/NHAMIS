namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetApproverIdfieldtovarchar100 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NominationApprovals", "ApproverId", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NominationApprovals", "ApproverId", c => c.String());
        }
    }
}
