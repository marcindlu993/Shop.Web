namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testbyMe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        IdAuthor = c.Int(nullable: false, identity: true),
                        NameAuthor = c.String(),
                        SecondNameAuthor = c.String(),
                    })
                .PrimaryKey(t => t.IdAuthor);
            
            CreateTable(
                "dbo.PublishingHouses",
                c => new
                    {
                        IdPublishingHouse = c.Int(nullable: false, identity: true),
                        NamePublishingHouse = c.String(),
                    })
                .PrimaryKey(t => t.IdPublishingHouse);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        IdResource = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdAuthor = c.Int(nullable: false),
                        IdPublishingHouse = c.Int(nullable: false),
                        IdTypeResource = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdResource)
                .ForeignKey("dbo.Authors", t => t.IdAuthor, cascadeDelete: true)
                .ForeignKey("dbo.PublishingHouses", t => t.IdPublishingHouse, cascadeDelete: true)
                .ForeignKey("dbo.TypeResources", t => t.IdTypeResource, cascadeDelete: true)
                .Index(t => t.IdAuthor)
                .Index(t => t.IdPublishingHouse)
                .Index(t => t.IdTypeResource);
            
            CreateTable(
                "dbo.TypeResources",
                c => new
                    {
                        IdTypeResource = c.Int(nullable: false, identity: true),
                        NameTypeResource = c.String(),
                    })
                .PrimaryKey(t => t.IdTypeResource);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "IdTypeResource", "dbo.TypeResources");
            DropForeignKey("dbo.Resources", "IdPublishingHouse", "dbo.PublishingHouses");
            DropForeignKey("dbo.Resources", "IdAuthor", "dbo.Authors");
            DropIndex("dbo.Resources", new[] { "IdTypeResource" });
            DropIndex("dbo.Resources", new[] { "IdPublishingHouse" });
            DropIndex("dbo.Resources", new[] { "IdAuthor" });
            DropTable("dbo.TypeResources");
            DropTable("dbo.Resources");
            DropTable("dbo.PublishingHouses");
            DropTable("dbo.Authors");
        }
    }
}
