namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedcolumnstatusonNominationApprovals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NominationApprovals", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NominationApprovals", "Status");
        }
    }
}
