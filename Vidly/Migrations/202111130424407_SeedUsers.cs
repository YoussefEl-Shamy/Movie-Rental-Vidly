namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2435e1c6-66e6-44ed-8991-2cbb1709faa6', N'admin@ye.com', 0, N'AL8g6+WeX+H5y0QUkAuHjgOAX11QpK7hXi9+FW79qwLhrTujE9Yln/jGSo4CZuqasg==', N'a68be7c0-59c0-4267-aa19-444a0e2b5bf7', NULL, 0, 0, NULL, 1, 0, N'admin@ye.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3066fdad-fa6e-44dc-8676-6e393c776bab', N'youssef.m5557@gmail.com', 0, N'AEFPyMj0KpoUc3Us1ED8BVnmyhOsvxD9yqb3KtZfX0OSU3a1JTJ9OpSjJY9cH5O5qQ==', N'd0fcc902-0b66-4d72-84bd-d5dab0a7901b', NULL, 0, 0, NULL, 1, 0, N'youssef.m5557@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ddf1776f-6f58-40de-986d-05bda0d06acb', N'omnia@love.com', 0, N'AB+noot8m3waPyjZLyJu2fTCB5/tSu5sL+UG6ypd0L8Tks2lCW91eWY2Nv2KLHkNEQ==', N'7844fbed-3352-4556-991d-6e7093f0d007', NULL, 0, 0, NULL, 1, 0, N'omnia@love.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'84b69308-2a0d-4860-bdc3-fb1e2311ce46', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2435e1c6-66e6-44ed-8991-2cbb1709faa6', N'84b69308-2a0d-4860-bdc3-fb1e2311ce46')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
