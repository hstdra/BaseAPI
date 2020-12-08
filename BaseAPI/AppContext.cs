using BaseAPI.Domain.RoomAggregate;
using Microsoft.EntityFrameworkCore;

namespace BaseAPI
{
    public class AppContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
