using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public interface IDataRepository
    {
        public Task CreateRace(BusInfo createRace);
        public IQueryable<BusInfo> GetAllRaces();
        public IQueryable<BusInfo> GetTodaysRaces();
        public BusInfo GetRaceById(int id);
        public Task UpdateRace(BusInfo updateRace);
        public Task DeleteRace(int id);
        public IQueryable<BusInfo> FindRace(string Location1, string Location2, DateTime Date);
        public Task AddPassengers(List<Passenger> Passengers);
        public int[] CountPlaceCurRace(DateTime DateRace, int raceId);
        public Task DeletePassengers();
        public BusInfo GetFirstBusInfo();
        public Task UpdateRaces();
    }
}
