namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingTheDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        EGN = c.Int(nullable: false),
                        Sex = c.String(),
                        Groups_Id = c.Int(),
                        Parents_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Groups_Id)
                .ForeignKey("dbo.Parents", t => t.Parents_Id)
                .Index(t => t.Groups_Id)
                .Index(t => t.Parents_Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EGN = c.Int(nullable: false),
                        Sex = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        Kids_Id = c.Int(),
                        Parents_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kids", t => t.Kids_Id)
                .ForeignKey("dbo.Parents", t => t.Parents_Id)
                .Index(t => t.Kids_Id)
                .Index(t => t.Parents_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Parents_Id", "dbo.Parents");
            DropForeignKey("dbo.Locations", "Kids_Id", "dbo.Kids");
            DropForeignKey("dbo.Kids", "Parents_Id", "dbo.Parents");
            DropForeignKey("dbo.Kids", "Groups_Id", "dbo.Groups");
            DropIndex("dbo.Locations", new[] { "Parents_Id" });
            DropIndex("dbo.Locations", new[] { "Kids_Id" });
            DropIndex("dbo.Kids", new[] { "Parents_Id" });
            DropIndex("dbo.Kids", new[] { "Groups_Id" });
            DropTable("dbo.Locations");
            DropTable("dbo.Parents");
            DropTable("dbo.Kids");
            DropTable("dbo.Groups");
            DropTable("dbo.Activities");
        }
    }
}
