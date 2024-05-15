using Microsoft.EntityFrameworkCore;

namespace YedWebApp1.Data
{
    public partial class MyAppDbContext : DbContext
    {
        public MyAppDbContext()
        {
        }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = WebApplication.CreateBuilder();
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
