namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	// Added the MembershipType.cs class, and also added MembershipType property and MembershipTypeId property
	// to the Customer model.
	// The package manager automatically made MembershipTypeId to a foreign key in the Customers table.
	public partial class AddMembershipType : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.MembershipTypes",
				c => new
					{
						Id = c.Byte(nullable: false),
						SignUpFee = c.Short(nullable: false),
						DurationInMonths = c.Byte(nullable: false),
						DiscountRate = c.Byte(nullable: false),
					})
				.PrimaryKey(t => t.Id);
			
			AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
			CreateIndex("dbo.Customers", "MembershipTypeId");
			AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
		}
		
		public override void Down()
		{
			DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
			DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
			DropColumn("dbo.Customers", "MembershipTypeId");
			DropTable("dbo.MembershipTypes");
		}
	}
}
