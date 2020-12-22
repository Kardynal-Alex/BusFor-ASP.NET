using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.DataBase
{
    public interface IDataRepository2
    {
        public Task CreateRace(PlaneInfo planeInfo);
        public Task DeleteRace(int id);
        public Task UpdateRace(PlaneInfo planeInfo);
        public IQueryable<PlaneInfo> GetTodaysRaces();
        public PlaneInfo GetRaceById(int id);
        public IQueryable<PlaneInfo> GetAllRaces();
        public IQueryable<PlaneInfo> FindRace(string Location1, string Location2, DateTime Date);
        public Task AddPassengers(List<PlanePassenger> Passengers);
    }
}
