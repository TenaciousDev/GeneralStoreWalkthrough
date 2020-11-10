namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgetCurrencyFormattingForNow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            AddColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "ProductId", c => c.Int());
            AlterColumn("dbo.Transactions", "CustomerId", c => c.Int());
            CreateIndex("dbo.Transactions", "ProductId");
            CreateIndex("dbo.Transactions", "CustomerId");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            AlterColumn("dbo.Transactions", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "Amount");
            CreateIndex("dbo.Transactions", "CustomerId");
            CreateIndex("dbo.Transactions", "ProductId");
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
