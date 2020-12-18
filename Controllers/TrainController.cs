using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
using BusFor.Models.DataBase;
using BusFor.Models.Service;
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
        public VanPlace vanPlace = null;
        public VanPlace isPlace = null;
        public VanPlace removeVanPlace = null;
        public IActionResult BuyPlatzKarteTicket(int raceId, int van, int place, int removePlace)
        {
            var race = repository1.GetRaceById(raceId);
            string[] VanArray = race.NumberOfPlatzKarte.Split('-');

            if (van != 0 && place != 0 ) 
            {
                vanPlace = new VanPlace() { Van = van, Place = place };
                isPlace = ListVanPlace.Where(x => x.Van == vanPlace.Van && x.Place == vanPlace.Place).FirstOrDefault();
            }
            if (van != 0 && removePlace != 0)
            {
                removeVanPlace = ListVanPlace.Where(x => x.Van == van && x.Place == removePlace).FirstOrDefault();
            }
            if (isPlace == null && van != 0 && place != 0) 
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
            var race = repository1.GetRaceById(raceId);
            string[] VanArray = race.NumberOfCoupe.Split('-');

            if (van != 0 && place != 0)
            {
                vanPlace = new VanPlace() { Van = van, Place = place };
                isPlace = ListVanPlace.Where(x => x.Van == vanPlace.Van && x.Place == vanPlace.Place).FirstOrDefault();
            }
            if (van != 0 && removePlace != 0)
            {
                removeVanPlace = ListVanPlace.Where(x => x.Van == van && x.Place == removePlace).FirstOrDefault();
            }
            if (isPlace == null && van != 0 && place != 0)
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
        public IActionResult EnterDataToBuyTicket(int raceId, string mode)
        {
            ViewBag.ListVanPlace = ListVanPlace;
            var TrainInfo = repository1.GetRaceById(raceId);
            ViewBag.Date = TrainInfo.Date1;
            ViewBag.raceId = raceId;
            ViewBag.Mode = mode; 
        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnterDataToBuyTicket(List<TrainPassenger> Passengers)
        {
            var trainInfo = repository1.GetRaceById(Passengers[0].TrainInfoId);
            foreach (var item in Passengers)
            {
                EmailTrainService emailTrainService = new EmailTrainService();
                await emailTrainService.SendEmailAsync(item, trainInfo);
            }
            ListVanPlace.Clear();
            //await repository1.AddPassengers(Passengers);
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
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
        [HttpPost]
        public async Task<IActionResult> CreateRace(TrainInfo trainInfo)
        {
            if (trainInfo.Date1 > trainInfo.Date2 || trainInfo.Date1 < DateTime.Now.Date || trainInfo.Date2 < DateTime.Now.Date)
            {
                ModelState.AddModelError("Date1", "Date1 must be less equal than Date2");
            }
            else
            if (trainInfo.Date1 == trainInfo.Date2 && trainInfo.Time1 >= trainInfo.Time2)
            {
                ModelState.AddModelError("Time1", "Time1 must be less equal than Time2");
            }
            else
            if (ModelState.IsValid)
            {
                await repository1.CreateRace(trainInfo);
                return RedirectToAction(nameof(ShowAllRaces));
            }
            return View();
        }
        public IActionResult EditRace(int id)
        {
            return View(repository1.GetRaceById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditRace(TrainInfo trainInfo)
        {
            if (trainInfo.Date1 > trainInfo.Date2 || trainInfo.Date1 < DateTime.Now.Date || trainInfo.Date2 < DateTime.Now.Date)
            {
                ModelState.AddModelError("Date1", "Date1 must be less equal than Date2");
            }
            else
            if (trainInfo.Date1 == trainInfo.Date2 && trainInfo.Time1 >= trainInfo.Time2)
            {
                ModelState.AddModelError("Time1", "Time1 must be less equal than Time2");
            }
            else
            if (ModelState.IsValid)
            {
                await repository1.UpdateRace(trainInfo);
                return RedirectToAction(nameof(ShowAllRaces));
            }
            return View();    
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRace(int id)
        {
            await repository1.DeleteRace(id);
            return RedirectToAction(nameof(ShowAllRaces));
        }
       
    }
}
