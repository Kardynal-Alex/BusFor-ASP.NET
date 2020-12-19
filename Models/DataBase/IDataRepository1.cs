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
        public Task DeleteRace(int id);
        public Task UpdateRace(TrainInfo trainInfo);
        public IQueryable<TrainInfo> GetAllRaces();
        public TrainInfo GetRaceById(int id);
        public IQueryable<TrainInfo> GetTodaysRaces();
        public IQueryable<TrainInfo> FindRace(string Location1, string Location2, DateTime Date);
        public Task AddPassengers(List<TrainPassenger> Passengers);
        public int[] CountPlaceCurRace(DateTime dateRace, int raceId, int van, string Mode);
    }
}
