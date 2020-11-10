namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormattingForCurrency : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
