using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public class EFDataRepository2 : IDataRepository2
    {
        private EFDatabaseContext context;
        public EFDataRepository2(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public async Task CreateRace(PlaneInfo planeInfo)
        {
            context.PlaneInfos.Add(planeInfo);
            await context.SaveChangesAsync();
        }
        public async Task DeleteRace(int id)
        {
            context.PlaneInfos.Remove(new PlaneInfo { Id = id });
            await context.SaveChangesAsync();
        }
        public async Task UpdateRace(PlaneInfo planeInfo)
        {
            PlaneInfo p = context.PlaneInfos.Find(planeInfo.Id);
            p.Date1 = planeInfo.Date1;
            p.Date2 = planeInfo.Date2;
            p.Time1 = planeInfo.Time1;
            p.Time2 = planeInfo.Time2;
            p.Location1 = planeInfo.Location1;
            p.Location2 = planeInfo.Location2;
            p.BusinessPrice = planeInfo.BusinessPrice;
            p.EconomPrice = planeInfo.EconomPrice;
            p.Platform = planeInfo.Platform;
            context.PlaneInfos.Update(p);
            await context.SaveChangesAsync();
        }
        public IQueryable<PlaneInfo> GetTodaysRaces() => context.PlaneInfos.Where(x => x.Date1 == DateTime.Now.Date).Select(x => x);
        public PlaneInfo GetRaceById(int id) => context.PlaneInfos.Find(id);
        public IQueryable<PlaneInfo> GetAllRaces() => context.PlaneInfos;
        public IQueryable<PlaneInfo> FindRace(string Location1, string Location2, DateTime Date)
        {
            return context.PlaneInfos.Where(x => x.Location1 == Location1 && x.Location2 == Location2 && x.Date1 == Date).Select(x => x);
        }
        public async Task AddPassengers(List<PlanePassenger> Passengers)
        {
            context.PlanePassengers.AddRange(Passengers);
            await context.SaveChangesAsync();
        }
        public List<IntStringPlace> SelectPlaceCurRace(DateTime dateRace, int raceId)
        {
            return context.PlanePassengers.Where(x => x.DateRace == dateRace && x.PlaneInfoId == raceId)
                .Select(x => new IntStringPlace { IntPlace = x.IntPlace, StringPlace = x.StringPlace }).ToList();
        }
        public PlaneInfo GetFirstPlaneInfo() => context.PlaneInfos.FirstOrDefault();
        public async Task DeletePassengers()
        {
            List<PlanePassenger> passengers = context.PlanePassengers.Where(x => x.DateRace < DateTime.Now.Date).Select(x => x).ToList();
            context.PlanePassengers.RemoveRange(passengers);
            await context.SaveChangesAsync();
        }
        public async Task UpdateRaces()
        {
            List<PlaneInfo> ListRaces = context.PlaneInfos.ToList();
            foreach (var item in ListRaces)
            {
                item.Date1 = item.Date1.AddDays(1);
                item.Date2 = item.Date2.AddDays(1);
            }
            context.PlaneInfos.UpdateRange(ListRaces);
            await context.SaveChangesAsync();
        }
    }
}
