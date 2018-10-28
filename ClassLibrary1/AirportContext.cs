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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = AirportDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crew>()
            .HasMany(c => c.Aviators)
            .WithOne(a => a.CrewObj)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Crew>()
            .HasMany(c => c.Stewardesses)
            .WithOne(s => s.CrewObj)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Crew>()
            .HasMany(c => c.Departures)
            .WithOne(f => f.CrewObj)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Flight>()
            .HasMany(f => f.Tickets)
            .WithOne(t => t.FlightObj)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Plane>()
            .HasMany(p => p.Departures)
            .WithOne(d => d.PlaneObj)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TypePlane>()
            .HasMany(p => p.Planes)
            .WithOne(d => d.Type)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Flight>()
            .HasMany(f => f.Departures)
            .WithOne(d => d.FlightObj)
            .OnDelete(DeleteBehavior.SetNull);
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