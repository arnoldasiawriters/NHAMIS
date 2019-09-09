namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
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
            
            AddColumn("dbo.Nomination", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Nomination", "CountryId");
            AddForeignKey("dbo.Nomination", "CountryId", "dbo.Country", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nomination", "CountryId", "dbo.Country");
            DropIndex("dbo.Nomination", new[] { "CountryId" });
            DropColumn("dbo.Nomination", "CountryId");
            DropTable("dbo.Country");
        }
    }
}
