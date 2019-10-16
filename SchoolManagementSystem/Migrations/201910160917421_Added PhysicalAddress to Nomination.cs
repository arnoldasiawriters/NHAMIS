namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhysicalAddresstoNomination : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nomination", "PhysicalAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nomination", "PhysicalAddress");
        }
    }
}
