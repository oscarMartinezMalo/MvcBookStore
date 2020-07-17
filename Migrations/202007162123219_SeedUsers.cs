namespace MvcBookStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02481b55-f183-491d-ba6b-a2f87c78b425', N'admin@gmail.com', 0, N'AL7t123kbedAhrB6rqRbS/4B4ih9Ct1Kkb4H97cXIriJaDPw2hvYYy5j/l8rG3zfKQ==', N'8bf76223-4233-41a5-9ba7-5eb9addf45c0', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bfc5fb33-66b6-45e9-8f71-f30f16fd8d5c', N'guest@gmail.com', 0, N'ALA78Rjovp70zWb1aoL0E+Z11zA2ogpijXyOYHJxHMt78fIPWz04QuT5BJzZdKfrXg==', N'89c46da6-33a3-4dc7-b671-5644db52f401', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'03302f39-fa31-48d2-a3ae-0d4f6374d5a9', N'CanManageBooks')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02481b55-f183-491d-ba6b-a2f87c78b425', N'03302f39-fa31-48d2-a3ae-0d4f6374d5a9')
                ");
        }

        public override void Down()
        {
        }
    }
}
