namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCountry : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Nomination", "CountryOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nomination", "CountryOfBirth", c => c.String());
        }
    }
}
