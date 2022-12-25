namespace RepoPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartModels",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CartId);
            
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        AmountPaid = c.Single(nullable: false),
                        ModeOfPayment = c.String(nullable: false),
                        OrderStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.PreviousOrdersModels",
                c => new
                    {
                        PreviousOrdersId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PreviousOrdersId);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.RoleModels",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.WalletModels",
                c => new
                    {
                        WalletId = c.Int(nullable: false, identity: true),
                        CurrentBalance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WalletId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WalletModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.RoleModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.PreviousOrdersModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.CartModels");
        }
    }
}
