namespace _02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flights", "Airport_Id", "dbo.Airports");
            DropIndex("dbo.Flights", new[] { "Airport_Id" });
            AddColumn("dbo.Flights", "AirportFrom_Id", c => c.Int());
            AddColumn("dbo.Flights", "AirportTo_Id", c => c.Int());
            AlterColumn("dbo.Airports", "Country_Id", c => c.Int());
            AlterColumn("dbo.Tickets", "User_Id", c => c.Int());
            CreateIndex("dbo.Flights", "AirportFrom_Id");
            CreateIndex("dbo.Flights", "AirportTo_Id");
            AddForeignKey("dbo.Flights", "AirportFrom_Id", "dbo.Airports", "Id");
            AddForeignKey("dbo.Flights", "AirportTo_Id", "dbo.Airports", "Id");
            DropColumn("dbo.Flights", "Airport_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "Airport_Id", c => c.Int());
            DropForeignKey("dbo.Flights", "AirportTo_Id", "dbo.Airports");
            DropForeignKey("dbo.Flights", "AirportFrom_Id", "dbo.Airports");
            DropIndex("dbo.Flights", new[] { "AirportTo_Id" });
            DropIndex("dbo.Flights", new[] { "AirportFrom_Id" });
            AlterColumn("dbo.Tickets", "User_Id", c => c.Int());
            AlterColumn("dbo.Airports", "Country_Id", c => c.Int());
            DropColumn("dbo.Flights", "AirportTo_Id");
            DropColumn("dbo.Flights", "AirportFrom_Id");
            CreateIndex("dbo.Flights", "Airport_Id");
            AddForeignKey("dbo.Flights", "Airport_Id", "dbo.Airports", "Id");
        }
    }
}
