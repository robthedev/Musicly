namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRentalModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "NumberAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "NumberAvailable", c => c.Byte(nullable: false));
        }
    }
}
