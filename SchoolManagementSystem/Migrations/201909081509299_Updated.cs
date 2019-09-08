namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttachmentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.NominationAttachment", "AttachmentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.NominationAttachment", "AttachmentTypeId");
            AddForeignKey("dbo.NominationAttachment", "AttachmentTypeId", "dbo.AttachmentType", "Id");
            DropColumn("dbo.NominationAttachment", "AttachmentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NominationAttachment", "AttachmentType", c => c.String());
            DropForeignKey("dbo.NominationAttachment", "AttachmentTypeId", "dbo.AttachmentType");
            DropIndex("dbo.NominationAttachment", new[] { "AttachmentTypeId" });
            DropColumn("dbo.NominationAttachment", "AttachmentTypeId");
            DropTable("dbo.AttachmentType");
        }
    }
}
