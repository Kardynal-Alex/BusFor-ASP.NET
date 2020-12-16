using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataBase;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public class EFDataRepository:IDataRepository
    {
        private EFDatabaseContext context;
        public EFDataRepository(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public async Task CreateRace(BusInfo createRace)
        {
            context.BusInfos.Add(createRace);
            await context.SaveChangesAsync();
        }
        public IQueryable<BusInfo> GetAllRaces() => context.BusInfos;
        public IQueryable<BusInfo> GetTodaysRaces() => context.BusInfos.Where(x => x.Date1 == DateTime.Now.Date).Select(x => x);
        public BusInfo GetRaceById(int id) => context.BusInfos.Find(id);
        public async Task UpdateRace(BusInfo updateRace)
        {
            context.BusInfos.Update(updateRace);
            await context.SaveChangesAsync();
        }
        public async Task DeleteRace(int id)
        {
            context.BusInfos.Remove(new BusInfo { Id = id });
            await context.SaveChangesAsync();
        }
        public IQueryable<BusInfo> FindRace(string Location1, string Location2, DateTime Date)
        {
            return context.BusInfos.Where(x => x.Location1 == Location1 && x.Location2 == Location2 && x.Date1 == Date).Select(x => x);
        }
        public async Task AddPassengers(List<Passenger> Passengers)
        {
            context.BusPassengers.AddRange(Passengers);
            await context.SaveChangesAsync();
        }
        public int[] CountPlaceCurRace(DateTime DateRace, int raceId)
        {
            return context.BusPassengers.Where(x => x.DateRace == DateRace && x.BusInfoId == raceId).Select(x => x.Place).ToArray();
        }
        public async Task DeletePassengers()
        {
            List<Passenger> passengers = context.BusPassengers.Where(x => x.DateRace < DateTime.Now.Date).Select(x => x).ToList();
            context.BusPassengers.RemoveRange(passengers);
            await context.SaveChangesAsync();
        }
        public BusInfo GetFirstBusInfo() => context.BusInfos.FirstOrDefault();
        public async Task UpdateRaces()
        {
            List<BusInfo> ListRaces = context.BusInfos.ToList();
            foreach (var item in ListRaces)
            {
                item.Date1 = item.Date1.AddDays(1);
                item.Date2 = item.Date2.AddDays(1);
            }
            context.BusInfos.UpdateRange(ListRaces);
            await context.SaveChangesAsync();
        }
    }
}
