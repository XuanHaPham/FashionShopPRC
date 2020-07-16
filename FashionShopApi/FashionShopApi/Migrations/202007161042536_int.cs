namespace FashionShopAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleID = c.Guid(),
                        AccountID = c.Guid(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Role", t => t.RoleID)
                .Index(t => t.RoleID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Fullname = c.String(),
                        Status = c.Boolean(),
                        Dob = c.DateTime(storeType: "date"),
                        Point = c.Int(),
                        ShippingAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountID = c.Guid(),
                        DeliverID = c.Guid(),
                        PromotionID = c.Guid(),
                        SubTotal = c.Double(),
                        ShippingFee = c.Double(),
                        Total = c.Double(),
                        Code = c.String(),
                        TimeCreated = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                        NoteForDeliver = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.DeliveryChannel", t => t.DeliverID)
                .ForeignKey("dbo.Promotions", t => t.PromotionID)
                .Index(t => t.AccountID)
                .Index(t => t.DeliverID)
                .Index(t => t.PromotionID);
            
            CreateTable(
                "dbo.BillDetail",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BillID = c.Guid(),
                        ProductID = c.Guid(),
                        Quantity = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bill", t => t.BillID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.BillID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryID = c.Guid(),
                        AccountID = c.Guid(),
                        Size = c.String(maxLength: 5, unicode: false),
                        Name = c.String(),
                        Code = c.String(),
                        Price = c.Double(),
                        Description = c.String(),
                        Overview = c.String(),
                        TimeCreated = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductPic",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImageURL = c.String(),
                        ProductID = c.Guid(),
                        Status = c.Boolean(),
                        TimeCreated = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.WishList",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductID = c.Guid(),
                        AccountID = c.Guid(),
                        Quantity = c.Int(),
                        TimeCreated = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.DeliveryChannel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyName = c.String(),
                        Overview = c.String(),
                        Status = c.Boolean(),
                        ShippingFee = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        Creater = c.Int(),
                        TimeCreated = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountID = c.Guid(),
                        Description = c.String(),
                        TimeCreated = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountRole", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Feedback", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Bill", "PromotionID", "dbo.Promotions");
            DropForeignKey("dbo.Bill", "DeliverID", "dbo.DeliveryChannel");
            DropForeignKey("dbo.WishList", "ProductID", "dbo.Product");
            DropForeignKey("dbo.WishList", "AccountID", "dbo.Account");
            DropForeignKey("dbo.ProductPic", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.BillDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "AccountID", "dbo.Account");
            DropForeignKey("dbo.BillDetail", "BillID", "dbo.Bill");
            DropForeignKey("dbo.Bill", "AccountID", "dbo.Account");
            DropForeignKey("dbo.AccountRole", "AccountID", "dbo.Account");
            DropIndex("dbo.Feedback", new[] { "AccountID" });
            DropIndex("dbo.WishList", new[] { "AccountID" });
            DropIndex("dbo.WishList", new[] { "ProductID" });
            DropIndex("dbo.ProductPic", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "AccountID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.BillDetail", new[] { "ProductID" });
            DropIndex("dbo.BillDetail", new[] { "BillID" });
            DropIndex("dbo.Bill", new[] { "PromotionID" });
            DropIndex("dbo.Bill", new[] { "DeliverID" });
            DropIndex("dbo.Bill", new[] { "AccountID" });
            DropIndex("dbo.AccountRole", new[] { "AccountID" });
            DropIndex("dbo.AccountRole", new[] { "RoleID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Role");
            DropTable("dbo.Feedback");
            DropTable("dbo.Promotions");
            DropTable("dbo.DeliveryChannel");
            DropTable("dbo.WishList");
            DropTable("dbo.ProductPic");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.BillDetail");
            DropTable("dbo.Bill");
            DropTable("dbo.Account");
            DropTable("dbo.AccountRole");
        }
    }
}
