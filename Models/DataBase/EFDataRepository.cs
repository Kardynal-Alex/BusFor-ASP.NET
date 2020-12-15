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
        public void CreateRace(BusInfo createRace)
        {
            context.BusInfos.Add(createRace);
            context.SaveChanges();
        }
        public IQueryable<BusInfo> GetAllRaces() => context.BusInfos;
        public IQueryable<BusInfo> GetTodaysRaces() => context.BusInfos.Where(x => x.Date1 == DateTime.Now.Date).Select(x => x);
        public BusInfo GetRaceById(int id) => context.BusInfos.Find(id);
        public void UpdateRace(BusInfo updateRace)
        {
            context.BusInfos.Update(updateRace);
            context.SaveChanges();
        }
        public void DeleteRace(int id)
        {
            context.BusInfos.Remove(new BusInfo { Id = id });
            context.SaveChanges();
        }
        public IQueryable<BusInfo> FindRace(string Location1, string Location2, DateTime Date)
        {
            return context.BusInfos.Where(x => x.Location1 == Location1 && x.Location2 == Location2 && x.Date1 == Date).Select(x => x);
        }
        public void AddPassengers(List<Passenger> Passengers)
        {
            context.BusPassengers.AddRange(Passengers);
            context.SaveChanges();
        }
        public int[] CountPlaceCurRace(DateTime DateRace, int raceId)
        {
            return context.BusPassengers.Where(x => x.DateRace == DateRace && x.BusInfoId == raceId).Select(x => x.Place).ToArray();
        }
        public void DeletePassengers()
        {
            List<Passenger> passengers = context.BusPassengers.Where(x => x.DateRace < DateTime.Now.Date).Select(x => x).ToList();
            context.BusPassengers.RemoveRange(passengers);
            context.SaveChanges();
        }
        public BusInfo GetFirstBusInfo()
        {
            return context.BusInfos.FirstOrDefault();
        }
    }
}
