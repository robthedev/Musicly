namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReleaseDateAndNumberInStockToSongModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Songs", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Name", c => c.String());
            DropColumn("dbo.Songs", "NumberInStock");
            DropColumn("dbo.Songs", "ReleaseDate");
        }
    }
}
