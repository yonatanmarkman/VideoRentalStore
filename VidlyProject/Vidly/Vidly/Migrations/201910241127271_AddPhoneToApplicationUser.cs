namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	// This migration was created from adding Phone
	// attribute to the ApplicationUser class (previously in IdentityModel).
	public partial class AddPhoneToApplicationUser : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 50));
		}
		
		public override void Down()
		{
			DropColumn("dbo.AspNetUsers", "Phone");
		}
	}
}
