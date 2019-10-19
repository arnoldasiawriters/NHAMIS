namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedHonourRoleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HonorRole", "MedalId", "dbo.Medal");
            DropForeignKey("dbo.HonorRole", "SalutationId", "dbo.Salutation");
            DropIndex("dbo.HonorRole", new[] { "SalutationId" });
            DropIndex("dbo.HonorRole", new[] { "MedalId" });
            AddColumn("dbo.HonorRole", "Title", c => c.String());
            AddColumn("dbo.HonorRole", "Medal", c => c.String());
            AddColumn("dbo.HonorRole", "Rank", c => c.String());
            AlterColumn("dbo.HonorRole", "ConfirementDate", c => c.DateTime());
            DropColumn("dbo.HonorRole", "SalutationId");
            DropColumn("dbo.HonorRole", "MedalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HonorRole", "MedalId", c => c.Int(nullable: false));
            AddColumn("dbo.HonorRole", "SalutationId", c => c.Int(nullable: false));
            AlterColumn("dbo.HonorRole", "ConfirementDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.HonorRole", "Rank");
            DropColumn("dbo.HonorRole", "Medal");
            DropColumn("dbo.HonorRole", "Title");
            CreateIndex("dbo.HonorRole", "MedalId");
            CreateIndex("dbo.HonorRole", "SalutationId");
            AddForeignKey("dbo.HonorRole", "SalutationId", "dbo.Salutation", "Id");
            AddForeignKey("dbo.HonorRole", "MedalId", "dbo.Medal", "Id");
        }
    }
}
