namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StandardizedNominationStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nomination", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nomination", "Status", c => c.String());
        }
    }
}
