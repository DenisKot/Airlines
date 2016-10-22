namespace _02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 512),
                        Coast = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeavingTime = c.DateTime(nullable: false),
                        Arrives = c.DateTime(nullable: false),
                        Airport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airports", t => t.Airport_Id)
                .Index(t => t.Airport_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Transaction = c.String(maxLength: 512),
                        Details = c.String(maxLength: 512),
                        Sit = c.String(maxLength: 16),
                        Email = c.String(maxLength: 512),
                        IsSetToEmail = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Login = c.String(maxLength: 256),
                        Password = c.String(maxLength: 256),
                        Email = c.String(maxLength: 256),
                        CardNumber = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Flights", "Airport_Id", "dbo.Airports");
            DropForeignKey("dbo.Airports", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            DropIndex("dbo.Flights", new[] { "Airport_Id" });
            DropIndex("dbo.Airports", new[] { "Country_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Flights");
            DropTable("dbo.Countries");
            DropTable("dbo.Airports");
        }
    }
}
