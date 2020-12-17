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
        [HttpPost]
        public async Task<IActionResult> CreateRace(TrainInfo trainInfo)
        {
            await repository1.CreateRace(trainInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
    }
}
