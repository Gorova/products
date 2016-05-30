namespace ManagingProducts.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        DateOfOperation = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        TypeOfOperationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfOperations", t => t.TypeOfOperationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.TypeOfOperationId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Operations", "TypeOfOperationId", "dbo.TypeOfOperations");
            DropForeignKey("dbo.Operations", "ProductId", "dbo.Products");
            DropIndex("dbo.Operations", new[] { "TypeOfOperationId" });
            DropIndex("dbo.Operations", new[] { "ProductId" });
            DropIndex("dbo.Operations", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.TypeOfOperations");
            DropTable("dbo.Products");
            DropTable("dbo.Operations");
        }
    }
}
