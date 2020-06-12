namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setrequiredonmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Kids", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Kids", "EGN", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Kids", "Sex", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "Address", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Locations", "City", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Parents", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Parents", "EGN", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Parents", "Sex", c => c.String(nullable: false));
            AlterColumn("dbo.Parents", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Parents", "Sex", c => c.String());
            AlterColumn("dbo.Parents", "EGN", c => c.String());
            AlterColumn("dbo.Parents", "Name", c => c.String());
            AlterColumn("dbo.Locations", "City", c => c.String());
            AlterColumn("dbo.Locations", "Address", c => c.String());
            AlterColumn("dbo.Groups", "Name", c => c.String());
            AlterColumn("dbo.Kids", "Sex", c => c.String());
            AlterColumn("dbo.Kids", "EGN", c => c.String());
            AlterColumn("dbo.Kids", "Name", c => c.String());
            AlterColumn("dbo.Activities", "Name", c => c.String());
        }
    }
}
