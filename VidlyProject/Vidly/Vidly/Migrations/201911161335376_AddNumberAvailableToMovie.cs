namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    // This migration was created by adding the property NumberAvailable to the Movie model.
    public partial class AddNumberAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            
            // This Sql method is required to initialize the NumberAvailable
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
