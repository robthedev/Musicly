namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPinCodeToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PinCode", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PinCode");
        }
    }
}
