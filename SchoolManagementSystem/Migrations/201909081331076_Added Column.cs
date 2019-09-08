namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medal", "Medal_Id", "dbo.Medal");
            DropIndex("dbo.Medal", new[] { "Medal_Id" });
            DropColumn("dbo.Medal", "Medal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medal", "Medal_Id", c => c.Int());
            CreateIndex("dbo.Medal", "Medal_Id");
            AddForeignKey("dbo.Medal", "Medal_Id", "dbo.Medal", "Id");
        }
    }
}
