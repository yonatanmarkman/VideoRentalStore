namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	// This migration was created without changing anything.
	// I created it to update records in the MembershipTypes table.

	// IMPORTANT NOTE: The database must be updated after every migration!
	// Or else the Sql statements won't execute.
	public partial class UpdateExistingRecords : DbMigration
	{
		public override void Up()
		{
			Sql("UPDATE MembershipTypes SET Name='Pay as you go' WHERE Id=1");
			Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE Id=2");
			Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE Id=3");
			Sql("UPDATE MembershipTypes SET Name='Annual' WHERE Id=4");
		}

		public override void Down()
		{
		}
	}
}
