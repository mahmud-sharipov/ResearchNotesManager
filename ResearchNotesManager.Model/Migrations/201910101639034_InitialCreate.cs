namespace ResearchNotesManager.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        UOM_Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.UnitOfMeasures", t => t.UOM_Guid, cascadeDelete: true)
                .Index(t => t.UOM_Guid);
            
            CreateTable(
                "dbo.Experiments",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Result = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Product_Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Products", t => t.Product_Guid, cascadeDelete: true)
                .Index(t => t.Product_Guid);
            
            CreateTable(
                "dbo.ProductLots",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Product_Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Products", t => t.Product_Guid, cascadeDelete: true)
                .Index(t => t.Product_Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UOM_Guid", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.ProductLots", "Product_Guid", "dbo.Products");
            DropForeignKey("dbo.Experiments", "Product_Guid", "dbo.Products");
            DropIndex("dbo.ProductLots", new[] { "Product_Guid" });
            DropIndex("dbo.Experiments", new[] { "Product_Guid" });
            DropIndex("dbo.Products", new[] { "UOM_Guid" });
            DropTable("dbo.ProductLots");
            DropTable("dbo.Experiments");
            DropTable("dbo.Products");
            DropTable("dbo.UnitOfMeasures");
        }
    }
}
