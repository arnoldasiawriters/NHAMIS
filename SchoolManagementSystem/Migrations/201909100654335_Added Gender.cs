namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateBy = c.String(maxLength: 128),
                        CreateDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 128),
                        ModifyDate = c.DateTime(),
                        Gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.Gender_Id)
                .Index(t => t.Gender_Id);
            
            AddColumn("dbo.Nomination", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Nomination", "GenderId");
            AddForeignKey("dbo.Nomination", "GenderId", "dbo.Gender", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nomination", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Gender", "Gender_Id", "dbo.Gender");
            DropIndex("dbo.Gender", new[] { "Gender_Id" });
            DropIndex("dbo.Nomination", new[] { "GenderId" });
            DropColumn("dbo.Nomination", "GenderId");
            DropTable("dbo.Gender");
        }
    }
}
