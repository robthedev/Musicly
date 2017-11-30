namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumberAvailToSongModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "NumberAvailable", c => c.Int(nullable: false));

            Sql("UPDATE Songs SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "NumberAvailable");
        }
    }
}
