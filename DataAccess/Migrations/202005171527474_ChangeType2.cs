namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kids", "EGN", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kids", "EGN", c => c.Int(nullable: false));
        }
    }
}
