namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTimestampToTransaction3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            AddColumn("dbo.Transactions", "TimeStamp", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Transactions", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "ProductId");
            CreateIndex("dbo.Transactions", "CustomerId");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            AlterColumn("dbo.Transactions", "CustomerId", c => c.Int());
            AlterColumn("dbo.Transactions", "ProductId", c => c.Int());
            DropColumn("dbo.Transactions", "TimeStamp");
            CreateIndex("dbo.Transactions", "CustomerId");
            CreateIndex("dbo.Transactions", "ProductId");
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
