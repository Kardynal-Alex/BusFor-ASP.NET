﻿using BusFor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
using BusFor.Models.DataBase;
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
            var TodaysRaces = repository.GetTodaysRaces();
            return View(TodaysRaces);
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
        public IActionResult CreateRace(BusInfo busInfo)
        {
            repository.CreateRace(busInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        public IActionResult EditRace(int id)
        {
            return View(repository.GetRaceById(id));
        }
        [HttpPost]
        public IActionResult EditRace(BusInfo busInfo)
        {
            repository.UpdateRace(busInfo);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        [HttpPost]
        public IActionResult DeleteRace(int id)
        {
            repository.DeleteRace(id);
            return RedirectToAction(nameof(ShowAllRaces));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}