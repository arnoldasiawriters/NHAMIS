namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataTypeofApprovalStageNameField2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApprovalStages", "Name", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApprovalStages", "Name", c => c.String());
        }
    }
}
