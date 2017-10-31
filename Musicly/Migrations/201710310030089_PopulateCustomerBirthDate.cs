namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate =  CAST('1980-01-01' AS DATETIME) WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
