using Microsoft.AspNetCore.Mvc;
using Rent.Data;
using Rent.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent.WebApp.Controllers
{
    public class DataHelper
    {
        public IList<Person> p;
        public IList<VideoGame> g;

        public DataHelper(IList<Person> p, IList<VideoGame> g)
        {
            this.p = p;
            this.g = g;
        }
    }

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
            DataHelper h = new DataHelper(personLogic.GetAllPeople(), gameLogic.GetAllGames());
            return View(h);
        }

        [HttpPost]
        public IActionResult NewRental(Rental r)
        {
            r.Game = gameLogic.GetGameById(r.GameRef);
            r.Person = personLogic.GetPersonById(r.PersonRef);
            rentLogic.NewRent(r);
            return RedirectToAction(nameof(GetRentals));
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
            return RedirectToAction(nameof(GetPeople));
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
            return RedirectToAction(nameof(GetGames));
        }

        public IActionResult ModifyGame(int id)
        {
            return View(gameLogic.GetGameById(id));
        }
    }
}
