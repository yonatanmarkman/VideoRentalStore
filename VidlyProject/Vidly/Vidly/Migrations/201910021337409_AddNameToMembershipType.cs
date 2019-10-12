namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	// This migration was created after adding Name property to MembershipType class.
	public partial class AddNameToMembershipType : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.MembershipTypes", "Name", c => c.String());
		}
		
		public override void Down()
		{
			DropColumn("dbo.MembershipTypes", "Name");
		}
	}
}
