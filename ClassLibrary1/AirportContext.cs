using Microsoft.EntityFrameworkCore;
using HometaskEntity.DAL.Models;

namespace HometaskEntity
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aviator> Aviators { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TypePlane> TypesPlane { get; set; }
    }
}