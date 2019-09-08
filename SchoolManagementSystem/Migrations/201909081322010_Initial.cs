namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicQualification",
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
                "dbo.Nomination",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdNumber = c.String(),
                        Surname = c.String(),
                        OtherNames = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(),
                        CountyOfBirth = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        Town = c.String(),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(),
                        Location = c.String(),
                        SubLocation = c.String(),
                        Village = c.String(),
                        PublicServiceRecords = c.String(),
                        Status = c.String(),
                        CountryOfBirth = c.String(),
                        WardId = c.Int(nullable: false),
                        SalutationId = c.Int(nullable: false),
                        NominationPeriodId = c.Int(nullable: false),
                        UserDetailsId = c.Int(nullable: false),
                        AcademicQualificationId = c.Int(nullable: false),
                        MedalId = c.Int(nullable: false),
                        NominatingBodyId = c.Int(nullable: false),
                        OccupationId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicQualification", t => t.AcademicQualificationId)
                .ForeignKey("dbo.Medal", t => t.MedalId)
                .ForeignKey("dbo.NominatingBody", t => t.NominatingBodyId)
                .ForeignKey("dbo.UserDetails", t => t.UserDetailsId)
                .ForeignKey("dbo.NominationPeriod", t => t.NominationPeriodId)
                .ForeignKey("dbo.Occupation", t => t.OccupationId)
                .ForeignKey("dbo.Salutation", t => t.SalutationId)
                .ForeignKey("dbo.Ward", t => t.WardId)
                .Index(t => t.WardId)
                .Index(t => t.SalutationId)
                .Index(t => t.NominationPeriodId)
                .Index(t => t.UserDetailsId)
                .Index(t => t.AcademicQualificationId)
                .Index(t => t.MedalId)
                .Index(t => t.NominatingBodyId)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.Medal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Quantity = c.Int(nullable: false),
                        OrderBy = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                        Medal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medal", t => t.Medal_Id)
                .Index(t => t.Medal_Id);
            
            CreateTable(
                "dbo.MedalTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionBy = c.String(),
                        Quantity = c.Int(nullable: false),
                        MedalId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medal", t => t.MedalId)
                .Index(t => t.MedalId);
            
            CreateTable(
                "dbo.NominationApprovals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovalDate = c.DateTime(nullable: false),
                        ApproverId = c.String(),
                        NominationId = c.Int(nullable: false),
                        ApprovalStagesId = c.Int(nullable: false),
                        MedalId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApprovalStages", t => t.ApprovalStagesId)
                .ForeignKey("dbo.Medal", t => t.MedalId)
                .ForeignKey("dbo.Nomination", t => t.NominationId)
                .Index(t => t.NominationId)
                .Index(t => t.ApprovalStagesId)
                .Index(t => t.MedalId);
            
            CreateTable(
                "dbo.ApprovalStages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NominatingBody",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ministry = c.String(),
                        Order = c.Int(nullable: false),
                        Category = c.String(),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Surname = c.String(),
                        OtherNames = c.String(),
                        Designation = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        Town = c.String(),
                        EmailAddress = c.String(),
                        MobileNo = c.String(),
                        OtherNo = c.String(),
                        UserId = c.String(),
                        UserStatus = c.Boolean(nullable: false),
                        NominatingBodyId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NominatingBody", t => t.NominatingBodyId)
                .Index(t => t.NominatingBodyId);
            
            CreateTable(
                "dbo.NominationPeriod",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        NominationDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Occupation",
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
                "dbo.Salutation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ward",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WardName = c.String(),
                        WardCode = c.String(),
                        SubCountyId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCounty", t => t.SubCountyId)
                .Index(t => t.SubCountyId);
            
            CreateTable(
                "dbo.SubCounty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCountyName = c.String(),
                        SubCountyCode = c.String(),
                        CountyId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.County", t => t.CountyId)
                .Index(t => t.CountyId);
            
            CreateTable(
                "dbo.County",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountyName = c.String(),
                        CountyCode = c.String(),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HonorRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SerialNo = c.String(),
                        IdNumber = c.String(),
                        ConfirementDate = c.DateTime(nullable: false),
                        Nationality = c.String(),
                        SalutationId = c.Int(nullable: false),
                        MedalId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medal", t => t.MedalId)
                .ForeignKey("dbo.Salutation", t => t.SalutationId)
                .Index(t => t.SalutationId)
                .Index(t => t.MedalId);
            
            CreateTable(
                "dbo.NominationAttachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttachmentType = c.String(),
                        AttachmentUrl = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nomination", t => t.nomination_Id)
                .ForeignKey("dbo.RecordType", t => t.RecordTypeId)
                .Index(t => t.RecordTypeId)
                .Index(t => t.nomination_Id);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(maxLength: 150),
                        ClaimValue = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 500),
                        SecurityStamp = c.String(maxLength: 500),
                        PhoneNumber = c.String(maxLength: 50),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.NomineeRecords", "RecordTypeId", "dbo.RecordType");
            DropForeignKey("dbo.NomineeRecords", "nomination_Id", "dbo.Nomination");
            DropForeignKey("dbo.NominationAttachment", "NominationId", "dbo.Nomination");
            DropForeignKey("dbo.HonorRole", "SalutationId", "dbo.Salutation");
            DropForeignKey("dbo.HonorRole", "MedalId", "dbo.Medal");
            DropForeignKey("dbo.Nomination", "WardId", "dbo.Ward");
            DropForeignKey("dbo.Ward", "SubCountyId", "dbo.SubCounty");
            DropForeignKey("dbo.SubCounty", "CountyId", "dbo.County");
            DropForeignKey("dbo.Nomination", "SalutationId", "dbo.Salutation");
            DropForeignKey("dbo.Nomination", "OccupationId", "dbo.Occupation");
            DropForeignKey("dbo.Nomination", "NominationPeriodId", "dbo.NominationPeriod");
            DropForeignKey("dbo.Nomination", "UserDetailsId", "dbo.UserDetails");
            DropForeignKey("dbo.UserDetails", "NominatingBodyId", "dbo.NominatingBody");
            DropForeignKey("dbo.Nomination", "NominatingBodyId", "dbo.NominatingBody");
            DropForeignKey("dbo.Nomination", "MedalId", "dbo.Medal");
            DropForeignKey("dbo.NominationApprovals", "NominationId", "dbo.Nomination");
            DropForeignKey("dbo.NominationApprovals", "MedalId", "dbo.Medal");
            DropForeignKey("dbo.NominationApprovals", "ApprovalStagesId", "dbo.ApprovalStages");
            DropForeignKey("dbo.MedalTransactions", "MedalId", "dbo.Medal");
            DropForeignKey("dbo.Medal", "Medal_Id", "dbo.Medal");
            DropForeignKey("dbo.Nomination", "AcademicQualificationId", "dbo.AcademicQualification");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.NomineeRecords", new[] { "nomination_Id" });
            DropIndex("dbo.NomineeRecords", new[] { "RecordTypeId" });
            DropIndex("dbo.NominationAttachment", new[] { "NominationId" });
            DropIndex("dbo.HonorRole", new[] { "MedalId" });
            DropIndex("dbo.HonorRole", new[] { "SalutationId" });
            DropIndex("dbo.SubCounty", new[] { "CountyId" });
            DropIndex("dbo.Ward", new[] { "SubCountyId" });
            DropIndex("dbo.UserDetails", new[] { "NominatingBodyId" });
            DropIndex("dbo.NominationApprovals", new[] { "MedalId" });
            DropIndex("dbo.NominationApprovals", new[] { "ApprovalStagesId" });
            DropIndex("dbo.NominationApprovals", new[] { "NominationId" });
            DropIndex("dbo.MedalTransactions", new[] { "MedalId" });
            DropIndex("dbo.Medal", new[] { "Medal_Id" });
            DropIndex("dbo.Nomination", new[] { "OccupationId" });
            DropIndex("dbo.Nomination", new[] { "NominatingBodyId" });
            DropIndex("dbo.Nomination", new[] { "MedalId" });
            DropIndex("dbo.Nomination", new[] { "AcademicQualificationId" });
            DropIndex("dbo.Nomination", new[] { "UserDetailsId" });
            DropIndex("dbo.Nomination", new[] { "NominationPeriodId" });
            DropIndex("dbo.Nomination", new[] { "SalutationId" });
            DropIndex("dbo.Nomination", new[] { "WardId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RecordType");
            DropTable("dbo.NomineeRecords");
            DropTable("dbo.NominationAttachment");
            DropTable("dbo.HonorRole");
            DropTable("dbo.County");
            DropTable("dbo.SubCounty");
            DropTable("dbo.Ward");
            DropTable("dbo.Salutation");
            DropTable("dbo.Occupation");
            DropTable("dbo.NominationPeriod");
            DropTable("dbo.UserDetails");
            DropTable("dbo.NominatingBody");
            DropTable("dbo.ApprovalStages");
            DropTable("dbo.NominationApprovals");
            DropTable("dbo.MedalTransactions");
            DropTable("dbo.Medal");
            DropTable("dbo.Nomination");
            DropTable("dbo.AcademicQualification");
        }
    }
}
