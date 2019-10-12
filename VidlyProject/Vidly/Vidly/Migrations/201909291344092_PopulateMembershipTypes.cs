namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	// Didn't change anything, so that's why the Up() and Down() started as empty functions - they didn't have automated code.
	// The Sql() queries were added manually.
	public partial class PopulateMembershipTypes : DbMigration
	{
		public override void Up()
		{
			Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
			Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
			Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
			Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
		}

		public override void Down()
		{

		}
	}
}
