namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Nomination", "PublicServiceRecords");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nomination", "PublicServiceRecords", c => c.String());
        }
    }
}
