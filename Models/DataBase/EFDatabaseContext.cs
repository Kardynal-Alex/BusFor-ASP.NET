using Microsoft.EntityFrameworkCore;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public class EFDatabaseContext:DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> opt) : base(opt) { }

        public DbSet<BusInfo> BusInfos { get; set; }
        public DbSet<Passenger> BusPassengers { get; set; }
    }
}
