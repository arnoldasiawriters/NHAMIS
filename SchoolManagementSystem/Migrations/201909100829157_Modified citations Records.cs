namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedcitationsRecords : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NomineeRecords", "nomination_Id", "dbo.Nomination");
            DropForeignKey("dbo.NomineeRecords", "RecordTypeId", "dbo.RecordType");
            DropIndex("dbo.NomineeRecords", new[] { "RecordTypeId" });
            DropIndex("dbo.NomineeRecords", new[] { "nomination_Id" });
            CreateTable(
                "dbo.CitationAchievement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionHeld = c.String(),
                        Project = c.String(),
                        Role = c.String(),
                        Achivement = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NominationId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nomination", t => t.NominationId)
                .Index(t => t.NominationId);
            
            CreateTable(
                "dbo.PreviousRecognition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecognizingInstitution = c.String(),
                        AchievementTitle = c.String(),
                        Award = c.String(),
                        AwardDate = c.DateTime(nullable: false),
                        NominationId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nomination", t => t.NominationId)
                .Index(t => t.NominationId);
            
            DropTable("dbo.NomineeRecords");
            DropTable("dbo.RecordType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecordType",
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
            
            CreateTable(
                "dbo.NomineeRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Organisation = c.String(),
                        Narration = c.String(),
                        RecordTypeId = c.Int(nullable: false),
                        NomineeId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                        nomination_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.PreviousRecognition", "NominationId", "dbo.Nomination");
            DropForeignKey("dbo.CitationAchievement", "NominationId", "dbo.Nomination");
            DropIndex("dbo.PreviousRecognition", new[] { "NominationId" });
            DropIndex("dbo.CitationAchievement", new[] { "NominationId" });
            DropTable("dbo.PreviousRecognition");
            DropTable("dbo.CitationAchievement");
            CreateIndex("dbo.NomineeRecords", "nomination_Id");
            CreateIndex("dbo.NomineeRecords", "RecordTypeId");
            AddForeignKey("dbo.NomineeRecords", "RecordTypeId", "dbo.RecordType", "Id");
            AddForeignKey("dbo.NomineeRecords", "nomination_Id", "dbo.Nomination", "Id");
        }
    }
}
