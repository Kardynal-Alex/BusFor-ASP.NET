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
    }
}
