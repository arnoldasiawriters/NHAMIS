namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataTypeofApprovalStageNameField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApprovalStages", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApprovalStages", "Name", c => c.Int(nullable: false));
        }
    }
}
