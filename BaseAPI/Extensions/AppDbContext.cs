using BaseAPI.DomainModels.RoomAggregate;
using Microsoft.EntityFrameworkCore;

namespace BaseAPI.Extensions
{
    public class AppDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
