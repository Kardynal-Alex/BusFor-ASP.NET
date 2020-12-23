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
    public class PlaneController : Controller
    {
        private IDataRepository2 repository2;
        public PlaneController(IDataRepository2 repo)
        {
            repository2 = repo;
        }
        public IActionResult PlaneSystem()
        {
            var TodaysRaces = repository2.GetTodaysRaces().OrderBy(x => x.Time1);
            return View(TodaysRaces);
        }
        public IActionResult FindRace(string Location1, string Location2, DateTime Date)
        {
            ListPlace.Clear();
            var findRace = repository2.FindRace(Location1, Location2, Date).OrderBy(x => x.Time1);
            ViewBag.returnUrl = HttpContext.Request.Path.ToString() + HttpContext.Request.QueryString;
            return View(findRace);
        }
        public static List<IntStringPlace> ListPlace = new List<IntStringPlace>();
        public IntStringPlace IntStringPlace = null;
        public IntStringPlace selectedPlace = null;
        public IntStringPlace selectToRemovePlace = null;
        public IActionResult BuyTicket(int raceId, int intPlace, string stringPlace, int removePlace, string returnUrl)
        {
            var race = repository2.GetRaceById(raceId);
            if (intPlace != 0 && stringPlace != "") 
            {
                IntStringPlace = new IntStringPlace() { IntPlace = intPlace, StringPlace = stringPlace };
                selectedPlace = ListPlace.Where(x => x.IntPlace == IntStringPlace.IntPlace && x.StringPlace == IntStringPlace.StringPlace).FirstOrDefault();
            }
            if (selectedPlace == null && intPlace != 0 && stringPlace != "") 
            {
                ListPlace.Add(IntStringPlace);
            }
            if (stringPlace != "" && removePlace != 0)
            {
                selectToRemovePlace = ListPlace.Where(x => x.IntPlace == removePlace && x.StringPlace == stringPlace).FirstOrDefault();
            }
            if (selectToRemovePlace != null && stringPlace != "" && removePlace != 0)
            {
                ListPlace.Remove(selectToRemovePlace);
            }

            ViewBag.RaceId = raceId;
            ViewBag.ListPlace = ListPlace;
            ViewBag.returnUrl = returnUrl;
            ViewBag.SoldPlace = repository2.SelectPlaceCurRace(race.Date1, race.Id);
           
            return View();
        }
        public IActionResult EnterDataToBuyTicket(int raceId)
        {
            var PlaneInfo = repository2.GetRaceById(raceId);
            ViewBag.PlaneInfo = PlaneInfo;
            ViewBag.ListPlace = ListPlace;
            ViewBag.Date = PlaneInfo.Date1;
            ViewBag.raceId = raceId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnterDataToBuyTicket(List<PlanePassenger> PlanePassengers)
        {
            var planeInfo = repository2.GetRaceById(PlanePassengers[0].PlaneInfoId);
            foreach (var item in PlanePassengers)
            {
                EmailPlaneService emailBusService = new EmailPlaneService();
                await emailBusService.SendEmailAsync(item, planeInfo);
            }
            ListPlace.Clear();
            await repository2.AddPassengers(PlanePassengers);
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }
        public IActionResult ShowAllRaces()
        {
            var AllRaces = repository2.GetAllRaces();
            return View(AllRaces);
        }
        public async Task<ActionResult> UpdateRaces()
        {
            var firstPlaneInfo = repository2.GetFirstPlaneInfo();
            if(firstPlaneInfo.Date1<DateTime.Now.Date)
            {
                await repository2.DeletePassengers();
                await repository2.UpdateRaces();
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }
        public IActionResult CreateRace()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRace(PlaneInfo planeInfo)
        {
            if (planeInfo.Date1 > planeInfo.Date2 || planeInfo.Date1 < DateTime.Now.Date || planeInfo.Date2 < DateTime.Now.Date)
            {
                ModelState.AddModelError("Date1", "Date1 must be less equal than Date2");
            }
            else
            if (planeInfo.Date1 == planeInfo.Date2 && planeInfo.Time1 >= planeInfo.Time2)
            {
                ModelState.AddModelError("Time1", "Time1 must be less equal than Time2");
            }
            else
            if (ModelState.IsValid)
            {
                await repository2.CreateRace(planeInfo);
                return RedirectToAction(nameof(ShowAllRaces));
            }
            return View();
        }
        public IActionResult EditRace(int id)
        {
            return View(repository2.GetRaceById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditRace(PlaneInfo planeInfo)
        {
            if (planeInfo.Date1 > planeInfo.Date2 || planeInfo.Date1 < DateTime.Now.Date || planeInfo.Date2 < DateTime.Now.Date)
            {
                ModelState.AddModelError("Date1", "Date1 must be less equal than Date2");
            }
            else
            if (planeInfo.Date1 == planeInfo.Date2 && planeInfo.Time1 >= planeInfo.Time2)
            {
                ModelState.AddModelError("Time1", "Time1 must be less equal than Time2");
            }
            else
            if (ModelState.IsValid)
            {
                await repository2.UpdateRace(planeInfo);
                return RedirectToAction(nameof(ShowAllRaces));
            }
            return View();
        }
    }
}
