using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
using BusFor.Models.DataBase;
namespace BusFor.Controllers
{
    public class TrainController : Controller
    {
        private IDataRepository1 repository1;
        public TrainController(IDataRepository1 repo1)
        {
            repository1 = repo1;
        }
        public IActionResult TrainSystem()
        {
            var TodaysRaces = repository1.GetTodaysRaces().OrderBy(x => x.Time1);
            return View(TodaysRaces);
        }
        public IActionResult FindRace(string Location1, string Location2, DateTime Date)
        {
            ListVanPlace.Clear();
            var findRace = repository1.FindRace(Location1, Location2, Date).OrderBy(x => x.Time1);
            return View(findRace);
        }
        public static List<VanPlace> ListVanPlace = new List<VanPlace>();
        public IActionResult BuyPlatzKarteTicket(int raceId, int van, int place, int removePlace)
        {
            var race = repository1.GetRaceById(raceId);
            string[] VanArray = race.NumberOfPlatzKarte.Split('-');

            VanPlace vanPlace = null;
            VanPlace removeVanPlace = null;
            if (van != 0 && place != 0 ) 
            {
                vanPlace = new VanPlace() { Van = van, Place = place };
            }
            if (van != 0 && removePlace != 0)
            {
                removeVanPlace = ListVanPlace.Where(x => x.Van == van && x.Place == removePlace).FirstOrDefault();
            }
            if (!ListVanPlace.Contains(vanPlace) && van != 0 && place != 0) 
            {
                ListVanPlace.Add(vanPlace);
            }
            if (removeVanPlace != null && van != 0 && removePlace != 0)  
            {
                ListVanPlace.Remove(removeVanPlace);
            }
            
            ViewBag.TrainInfo = race;
            ViewBag.raceId = raceId;
            ViewBag.ListVanPlace = ListVanPlace;
            
            ViewBag.VanArray = VanArray;
            ViewBag.CurVan = Convert.ToString(van) == "0" ? VanArray[0] : Convert.ToString(van);
            return View();
        }
        public IActionResult BuyCoupeTicket(int raceId, int van, int place, int removePlace)
        {

            return View();
        }
        public IActionResult ShowAllRaces()
        {
            var AllRaces = repository1.GetAllRaces();
            return View(AllRaces);
        }
        public IActionResult CreateRace()
        {
            return View();
        }
        public IActionResult EditRace(int id)
        {
            return View(repository1.GetRaceById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditRace(TrainInfo trainInfo)
        {
            await repository1.UpdateRace(trainInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRace(int id)
        {
            await repository1.DeleteRace(id);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        [HttpPost]
        public async Task<IActionResult> CreateRace(TrainInfo trainInfo)
        {
            await repository1.CreateRace(trainInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
    }
}
