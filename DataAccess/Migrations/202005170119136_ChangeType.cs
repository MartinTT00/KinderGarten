namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parents", "EGN", c => c.String());
            AlterColumn("dbo.Parents", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Parents", "EGN", c => c.Int(nullable: false));
        }
    }
}
