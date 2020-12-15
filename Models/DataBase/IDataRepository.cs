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
        public IQueryable<BusInfo> FindRace(string Location1, string Location2, DateTime Date);
        public void AddPassengers(List<Passenger> Passengers);
        public int[] CountPlaceCurRace(DateTime DateRace, int raceId);
        public void DeletePassengers();
        public BusInfo GetFirstBusInfo();
    }
}
