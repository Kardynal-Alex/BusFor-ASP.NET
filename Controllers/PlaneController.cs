using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
using BusFor.Models.DataBase;
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
            //ListPlace.Clear();
            var findRace = repository2.FindRace(Location1, Location2, Date).OrderBy(x => x.Time1);
            //ViewBag.returnUrl = HttpContext.Request.Path.ToString() + HttpContext.Request.QueryString;
            return View(findRace);
        }
        public IActionResult BuyTicket(int id)
        {
            return View();
        }
        public IActionResult ShowAllRaces()
        {
            var AllRaces = repository2.GetAllRaces();
            return View(AllRaces);
        }
        public IActionResult CreateRace()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRace(PlaneInfo planeInfo)
        {
            await repository2.CreateRace(planeInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        public IActionResult EditRace(int id)
        {
            return View(repository2.GetRaceById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditRace(PlaneInfo planeInfo)
        {
            await repository2.UpdateRace(planeInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
    }
}
