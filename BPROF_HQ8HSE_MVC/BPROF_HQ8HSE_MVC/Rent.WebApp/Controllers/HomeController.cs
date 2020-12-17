using Microsoft.AspNetCore.Mvc;
using Rent.Data;
using Rent.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent.WebApp.Controllers
{
    public class HomeController : Controller
    {
        RentLogic rentLogic;
        VideoGameLogic gameLogic;
        PersonLogic personLogic;

        public HomeController(RentLogic rentLogic, VideoGameLogic gameLogic, PersonLogic personLogic)
        {
            this.rentLogic = rentLogic;
            this.gameLogic = gameLogic;
            this.personLogic = personLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetRentals()
        {
            return View(rentLogic.GetAllRentals());
        }

        [HttpGet]
        public IActionResult NewRental()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewRental(Rental r)
        {
            rentLogic.NewRent(r.GameRef, r.PersonRef, r.RentDate, r.ReturnDate);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ModifyRental(int id)
        {
            return View(rentLogic.GetRentById(id));
        }

        public IActionResult GetPeople()
        {
            return View(personLogic.GetAllPeople());
        }

        [HttpGet]
        public IActionResult NewPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPerson(Person p)
        {
            personLogic.NewPerson(p.Name, p.BirthDate);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ModifyPerson(int id)
        {
            return View(personLogic.GetPersonById(id));
        }

        public IActionResult GetGames()
        {
            return View(gameLogic.GetAllGames());
        }

        [HttpGet]
        public IActionResult NewGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewGame(VideoGame v)
        {
            gameLogic.NewGame(v.Name, v.ReleaseDate, v.Publisher, v.Rating);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ModifyGame(int id)
        {
            return View(gameLogic.GetGameById(id));
        }
    }
}
