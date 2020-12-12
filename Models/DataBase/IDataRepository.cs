using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public interface IDataRepository
    {
        public void CreateRace(BusInfo createRace);
        public IQueryable<BusInfo> GetAllRaces();
        public IQueryable<BusInfo> GetTodaysRaces();
        public BusInfo GetRaceById(int id);
        public void UpdateRace(BusInfo updateRace);
        public void DeleteRace(int id);
    }
}
