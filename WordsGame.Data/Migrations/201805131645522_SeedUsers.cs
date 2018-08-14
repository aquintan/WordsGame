namespace WordsGame.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
//            Sql(@"
//                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'85e77f8f-970e-429e-801a-4edc40935c3d', N'admin1@gmail.com', 0, N'AC2EEmjJiMuLyENHXI/bQqEUr3LW4F4Ju0qVqbPeCxkMA/SHA0Xl/IrVqSwpUCC+UQ==', N'fd815a9a-921a-44a2-92bf-8f4a69dd51ce', NULL, 0, 0, NULL, 1, 0, N'admin1')
//                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fd7c3343-4791-4c91-ae3f-1c3b071257e9', N'user1@mail.com', 0, N'AOWCJVXfkDPSDcwJRe6ShVLFEjvST1+LBWOUlptax61X4L+3rmYE2xFduN3RbUUdug==', N'e1010f76-4a68-40a4-8790-5844e7549a16', NULL, 0, 0, NULL, 1, 0, N'user1')
//                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3d6b70a7-94b0-4cbb-8f23-2e5083463aac', N'AdminRole')
//                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dc24e02d-71c4-414f-935e-a52d280a693e', N'UserRole')
//                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'85e77f8f-970e-429e-801a-4edc40935c3d', N'3d6b70a7-94b0-4cbb-8f23-2e5083463aac')
//                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fd7c3343-4791-4c91-ae3f-1c3b071257e9', N'dc24e02d-71c4-414f-935e-a52d280a693e')  
//            ");
        }
        
        public override void Down()
        {
        }
    }
}
