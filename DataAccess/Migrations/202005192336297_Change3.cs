namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KidActivities",
                c => new
                    {
                        Kid_Id = c.Int(nullable: false),
                        Activity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kid_Id, t.Activity_Id })
                .ForeignKey("dbo.Kids", t => t.Kid_Id, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.Kid_Id)
                .Index(t => t.Activity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KidActivities", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.KidActivities", "Kid_Id", "dbo.Kids");
            DropIndex("dbo.KidActivities", new[] { "Activity_Id" });
            DropIndex("dbo.KidActivities", new[] { "Kid_Id" });
            DropTable("dbo.KidActivities");
        }
    }
}
