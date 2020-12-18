using BusFor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
using BusFor.Models.DataBase;
using BusFor.Models.Service;
namespace BusFor.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;

        public HomeController(IDataRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BusSystem()
        {
            var TodaysRaces = repository.GetTodaysRaces().OrderBy(x => x.Time1);
            return View(TodaysRaces);
        }
        public async Task<IActionResult> UpdateRaces()
        {
            var firstBusInfo = repository.GetFirstBusInfo();
            if (firstBusInfo.Date1 < DateTime.Now.Date)
            {
                await repository.DeletePassengers();
                await repository.UpdateRaces();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult FindRace(string Location1, string Location2, DateTime Date)
        {
            ListPlace.Clear();
            var findRace = repository.FindRace(Location1, Location2, Date).OrderBy(x => x.Time1);
            return View(findRace);
        }
        public static List<int> ListPlace = new List<int>();
        public IActionResult BuyTicket(int id, int place,int removePlace)
        {
            if (!ListPlace.Contains(place) && place != 0) 
            {
                ListPlace.Add(place);
            }
            if (ListPlace.Contains(removePlace) && removePlace != 0) 
            {
                ListPlace.Remove(removePlace);
            }
            var race = repository.GetRaceById(id);
            ViewBag.BusInfo = race;
            ViewBag.raceId = id;
            ViewBag.List = ListPlace;
            ViewBag.SoldPlace = repository.CountPlaceCurRace(race.Date1, id);
            return View();
        }
        public IActionResult EnterDataToBuyTicket(int raceId)
        {
            ViewBag.ListPlace = ListPlace;
            var BusInfo = repository.GetRaceById(raceId);
            ViewBag.Date = BusInfo.Date1;
            ViewBag.raceId = raceId;
            ViewBag.TotalPrice = BusInfo.Price * (ListPlace.Count());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnterDataToBuyTicket(List<Passenger> Passengers)
        {
            var busInfo = repository.GetRaceById(Passengers[0].BusInfoId);
            foreach (var item in Passengers)
            {
                EmailBusService emailBusService = new EmailBusService();
                await emailBusService.SendEmailAsync(item, busInfo);
            }
            ListPlace.Clear();
            await repository.AddPassengers(Passengers);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ShowAllRaces()
        {
            var AllRaces = repository.GetAllRaces();
            return View(AllRaces);
        }
        public IActionResult CreateRace()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRace(BusInfo busInfo)
        {
            if (busInfo.Date1 > busInfo.Date2 && busInfo.Date1 >= DateTime.Now.Date && busInfo.Date2 >= DateTime.Now.Date)   
            {
                ModelState.AddModelError("Date1", "Date1 must be less equal than Date2");
            }
            else
            {
                await repository.CreateRace(busInfo);
                return RedirectToAction(nameof(ShowAllRaces));
            }
            return View();
        }
        public IActionResult EditRace(int id)
        {
            return View(repository.GetRaceById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditRace(BusInfo busInfo)
        {
            await repository.UpdateRace(busInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRace(int id)
        {
            await repository.DeleteRace(id);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
