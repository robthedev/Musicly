namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSongsTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Songs ON");
            Sql("INSERT INTO Songs (Id, Name, GenreId) VALUES (1, 'Sadness', 2)");
            Sql("INSERT INTO Songs (Id, Name, GenreId) VALUES (2, 'Hard Knock Life', 1)");
            Sql("INSERT INTO Songs (Id, Name, GenreId) VALUES (3, 'Chant', 2)");
            Sql("INSERT INTO Songs (Id, Name, GenreId) VALUES (4, 'Light Gernades', 3)");
            Sql("INSERT INTO Songs (Id, Name, GenreId) VALUES (5, '9th Symphony', 4)");
            Sql("SET IDENTITY_INSERT Songs OFF");
        }
        
        public override void Down()
        {
        }
    }
}
