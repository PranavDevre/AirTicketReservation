using AIR_RESERVATION_SYSTEM_API.Model;
using ATRWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AIR_RESERVATION_SYSTEM_API.Context
{
    public class AIRDbContext : DbContext
    {
        //ConstructorDependencices
        public AIRDbContext(DbContextOptions<AIRDbContext> Context) : base(Context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasNoKey();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.emailId)
                .IsUnique();

        }



        public DbSet<Flights> FlightsDetails { get; set; }
        public DbSet<Admin> AdminDetails { get; set; }

        public DbSet<User> UserDetails { get; set; }
        public DbSet<Ticket> FlightMaster { get; set; }



    }
}
