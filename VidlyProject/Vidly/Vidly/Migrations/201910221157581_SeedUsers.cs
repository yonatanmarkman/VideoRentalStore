namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	// This migration started as an empty one,
	// Because at first we have not modified our domain model.
	// This migration will use SQL to add two users with roles to the DB.
	public partial class SeedUsers : DbMigration
	{
		public override void Up()
		{
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a20f4575-72a5-4334-811a-2650d8e0882f', N'admin@vidly.com', 0, N'ANDBE6TXlzyh9zuM95e6Bd/xAPMCmy3+UFUfdLeMt7yAd58r5RekJaqe7OALPS9kfA==', N'b9acc971-5610-4551-90f8-d9b4259b68c3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f426eb9c-d40e-4ea7-8445-042db57f7cd0', N'guest@vidly.com', 0, N'AEU7rH0+A3qSvysMyk9UOxHtZWqGIvjOnChudTdsJmdiY37bkP/Z8uvRYd7ZJ9VG2Q==', N'6c67b2f6-d449-462d-9f9a-cb84e9cd7b9c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2fa5191a-d97a-4c54-aa9b-74f50f4e969d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a20f4575-72a5-4334-811a-2650d8e0882f', N'2fa5191a-d97a-4c54-aa9b-74f50f4e969d')

");
		}
		
		public override void Down()
		{
		}
	}
}
