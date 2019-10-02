namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedafieldOrdertoApprovalStages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApprovalStages", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApprovalStages", "Order");
        }
    }
}
