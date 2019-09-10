namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedGender : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gender", "Gender_Id", "dbo.Gender");
            DropIndex("dbo.Gender", new[] { "Gender_Id" });
            DropColumn("dbo.Gender", "Gender_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gender", "Gender_Id", c => c.Int());
            CreateIndex("dbo.Gender", "Gender_Id");
            AddForeignKey("dbo.Gender", "Gender_Id", "dbo.Gender", "Id");
        }
    }
}
