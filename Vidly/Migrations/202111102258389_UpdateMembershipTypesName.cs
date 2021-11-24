namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypesName : DbMigration
    {
        public override void Up()
        {
            Sql("update membershipTypes set name = 'Pay as You Go' where discountRate = 0");
            Sql("update membershipTypes set name = 'Monthly' where discountRate = 10");
            Sql("update membershipTypes set name = 'Quarterly' where discountRate = 15");
            Sql("update membershipTypes set name = 'Annual' where discountRate = 20");
        }
        
        public override void Down()
        {
        }
    }
}
