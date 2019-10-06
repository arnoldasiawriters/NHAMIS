namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateOfBirthColumnnullableforNomination : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nomination", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nomination", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
