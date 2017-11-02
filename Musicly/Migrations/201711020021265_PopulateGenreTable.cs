namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Hip-hop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'EDM')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Classical')");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
    }
}
