namespace Musicly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4485cb5a-24ca-4507-9e54-9f8065f9127a', N'guest@musicly.com', 0, N'AMl+1NbTobL9UMEJKmeauiZw2cUno6qeApo16/3p3FuaIP/dTXlAugkKW2ms7fhV2A==', N'58406f9d-8c54-4542-8da8-e225488ae7ed', NULL, 0, 0, NULL, 1, 0, N'guest@musicly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'786823c1-cbc9-4599-8dc2-4cee127f9fc5', N'admin@musicly.com', 0, N'ANnVcbIP/lVXzjCh5OTZjTE5IQscWUPYERvKR3SY44a4POoVyXUmfmvI5JOJBMNiQA==', N'6c61d9f4-6e10-4924-9a6a-bc1153d385c0', NULL, 0, 0, NULL, 1, 0, N'admin@musicly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bda17210-1cc6-4b1a-aab5-80ac87e68812', N'canManageMovies')


                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'786823c1-cbc9-4599-8dc2-4cee127f9fc5', N'bda17210-1cc6-4b1a-aab5-80ac87e68812')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
