namespace Agathas.Storefront.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size_Id = c.Int(),
                        Title_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductSize", t => t.Size_Id)
                .ForeignKey("dbo.ProductTitle", t => t.Title_Id)
                .Index(t => t.Size_Id)
                .Index(t => t.Title_Id);
            
            CreateTable(
                "dbo.ProductSize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Brand_Id = c.Int(),
                        Category_Id = c.Int(),
                        Color_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.Brand_Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.ProductColor", t => t.Color_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Color_Id);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductColor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Title_Id", "dbo.ProductTitle");
            DropForeignKey("dbo.ProductTitle", "Color_Id", "dbo.ProductColor");
            DropForeignKey("dbo.ProductTitle", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.ProductTitle", "Brand_Id", "dbo.Brand");
            DropForeignKey("dbo.Product", "Size_Id", "dbo.ProductSize");
            DropIndex("dbo.ProductTitle", new[] { "Color_Id" });
            DropIndex("dbo.ProductTitle", new[] { "Category_Id" });
            DropIndex("dbo.ProductTitle", new[] { "Brand_Id" });
            DropIndex("dbo.Product", new[] { "Title_Id" });
            DropIndex("dbo.Product", new[] { "Size_Id" });
            DropTable("dbo.ProductColor");
            DropTable("dbo.Brand");
            DropTable("dbo.ProductTitle");
            DropTable("dbo.ProductSize");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
