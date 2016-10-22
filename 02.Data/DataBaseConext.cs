namespace _02.Data
{
    using System.Data.Entity;
    using _01.Domain.Models;

    public class DataBaseConext : DbContext
    {
        public virtual DbSet<Airport> Airports { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public DataBaseConext()
            : base("DataBaseConext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
    }
}