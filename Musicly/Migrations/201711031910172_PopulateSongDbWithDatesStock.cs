namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSongDbWithDatesStock : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Songs SET ReleaseDate = CAST('2017-01-01' AS DATETIME), NumberInStock = 5 WHERE Id = 1");
            Sql("UPDATE Songs SET ReleaseDate = CAST('2010-04-20' AS DATETIME), NumberInStock = 10 WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
