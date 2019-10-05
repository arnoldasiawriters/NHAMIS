namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedroletostages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApprovalStages", "RoleId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApprovalStages", "RoleId");
        }
    }
}
