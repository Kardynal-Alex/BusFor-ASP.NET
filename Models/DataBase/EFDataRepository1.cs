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
        public IQueryable<TrainInfo> GetAllRaces() => context.TrainInfos;
    }
}
