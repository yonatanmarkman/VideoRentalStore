namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	// This migration was created from adding DrivingLicense
	// attribute to the ApplicationUser class (previously in IdentityModel).
	public partial class AddDrivingLicenseToApplicationUser : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
		}
		
		public override void Down()
		{
			DropColumn("dbo.AspNetUsers", "DrivingLicense");
		}
	}
}
