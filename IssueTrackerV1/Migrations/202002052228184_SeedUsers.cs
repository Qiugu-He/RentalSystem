namespace IssueTrackerV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'638dd765-045c-45c5-94f0-9aa30f085620', N'admin@123.com', 0, N'AB5G7GgqiqX0hc+IzN0KrbVhfTjYYcCCpxS2dfdccrE5RNlbafw7jt7Ti4KIUmfo8Q==', N'ca737ca4-0e71-4793-88fa-8cefde52f0a0', NULL, 0, 0, NULL, 1, 0, N'admin@123.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dada597c-cdcd-4dc7-8a18-f7476311b2a1', N'guest@123.com', 0, N'AKrgpORfo29TLfXCjLNn6vmoWRKN9gb4ElMEgn0YR9mrZGXyeUqIVHjFNYaFIhPqSQ==', N'1e2b0b7f-2e94-4b35-aca1-381308e9172f', NULL, 0, 0, NULL, 1, 0, N'guest@123.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e7c5fc8b-6814-40d1-8622-f9491da92330', N'CanManageIssues')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'638dd765-045c-45c5-94f0-9aa30f085620', N'e7c5fc8b-6814-40d1-8622-f9491da92330')

");
        }
        
        public override void Down()
        {
        }
    }
}
