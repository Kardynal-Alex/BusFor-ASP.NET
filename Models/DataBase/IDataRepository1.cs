using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public interface IDataRepository1
    {
        public Task CreateRace(TrainInfo trainInfo);
        public IQueryable<TrainInfo> GetAllRaces();
    }
}
