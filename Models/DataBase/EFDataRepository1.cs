using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public class EFDataRepository1:IDataRepository1
    {
        private EFDatabaseContext context;
        public EFDataRepository1(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public async Task CreateRace(TrainInfo trainInfo)
        {
            context.TrainInfos.Add(trainInfo);
            await context.SaveChangesAsync();
        }
        public async Task UpdateRace(TrainInfo trainInfo)
        {
            TrainInfo t = context.TrainInfos.Find(trainInfo.Id);
            t.Date1 = trainInfo.Date1;
            t.Date2 = trainInfo.Date2;
            t.Time1 = trainInfo.Time1;
            t.Time2 = trainInfo.Time2;
            t.Location1 = trainInfo.Location1;
            t.Location2 = trainInfo.Location2;
            t.Platform = trainInfo.Platform;
            t.NumberOfCoupe = trainInfo.NumberOfCoupe;
            t.NumberOfPlatzKarte = trainInfo.NumberOfPlatzKarte;
            t.CoupePrice = trainInfo.CoupePrice;
            t.PlatzKartePrice = trainInfo.PlatzKartePrice;
            context.TrainInfos.Update(t);
            await context.SaveChangesAsync();
        }
        public async Task DeleteRace(int id)
        {
            context.TrainInfos.Remove(new TrainInfo { Id = id });
            await context.SaveChangesAsync();
        }
        public IQueryable<TrainInfo> GetAllRaces() => context.TrainInfos;
        public TrainInfo GetRaceById(int id) => context.TrainInfos.Find(id);
        public IQueryable<TrainInfo> GetTodaysRaces()=> context.TrainInfos.Where(x => x.Date1 == DateTime.Now.Date).Select(x => x);
        public IQueryable<TrainInfo> FindRace(string Location1, string Location2, DateTime Date)
        {
            return context.TrainInfos.Where(x => x.Location1 == Location1 && x.Location2 == Location2 && x.Date1 == Date).Select(x => x);
        }
        public async Task AddPassengers(List<TrainPassenger> Passengers)
        {
            context.TrainPassengers.AddRange(Passengers);
            await context.SaveChangesAsync();
        }
        public int[] CountPlaceCurRace(DateTime dateRace, int raceId, int van, string Mode)
        {
            return context.TrainPassengers.Where(x => x.DateRace == dateRace && x.TrainInfoId == raceId && x.Mode == Mode && x.Van == van)
                .Select(x => x.Place).ToArray();
        }
        public TrainInfo GetFirstTrainInfo() => context.TrainInfos.FirstOrDefault();
        public async Task DeletePassengers()
        {
            List<TrainPassenger> passengers = context.TrainPassengers.Where(x => x.DateRace < DateTime.Now.Date).Select(x => x).ToList();
            context.TrainPassengers.RemoveRange(passengers);
            await context.SaveChangesAsync();
        }
        public async Task UpdateRaces()
        {
            List<TrainInfo> ListRaces = context.TrainInfos.ToList();
            foreach (var item in ListRaces)
            {
                item.Date1 = item.Date1.AddDays(1);
                item.Date2 = item.Date2.AddDays(1);
            }
            context.TrainInfos.UpdateRange(ListRaces);
            await context.SaveChangesAsync();
        }
    }
}
