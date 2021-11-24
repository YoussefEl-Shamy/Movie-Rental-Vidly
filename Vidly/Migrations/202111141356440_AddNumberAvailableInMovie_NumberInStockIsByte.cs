namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableInMovie_NumberInStockIsByte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "numberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "numberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "numberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "numberAvailable");
        }
    }
}
