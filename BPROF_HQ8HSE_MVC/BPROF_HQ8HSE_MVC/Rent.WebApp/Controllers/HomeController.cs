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
        public Rental r;

        public DataHelper(IList<Person> p, IList<VideoGame> g)
        {
            this.p = p;
            this.g = g;
        }

        public DataHelper(IList<Person> p, IList<VideoGame> g, Rental r)
        {
            this.p = p;
            this.g = g;
            this.r = r;
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

        public IActionResult NonCRUDMethods()
        {
            return View();
        }

        public IActionResult GetQueries()
        {
            return View(rentLogic);
        }

        #region Rentals

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
        public IActionResult NewRental(int PersonRef, int GameRef, DateTime RentDate, DateTime ReturnDate)
        {
            Rental r = new Rental()
            {
                PersonRef = PersonRef,
                GameRef = GameRef,
                RentDate = RentDate,
                ReturnDate = ReturnDate
            };
            rentLogic.NewRent(r);
            return RedirectToAction(nameof(GetRentals));
        }

        [HttpGet]
        public IActionResult ModifyRental(int id)
        {
            DataHelper h = new DataHelper(personLogic.GetAllPeople(), gameLogic.GetAllGames(), rentLogic.GetRentById(id));
            return View(h);
        }

        [HttpPost]
        public IActionResult ModifyRental(int PersonRef, int GameRef, DateTime RentDate, DateTime ReturnDate, int Id)
        {
            rentLogic.ChangePersonRef(Id, PersonRef);
            rentLogic.ChangeGameRef(Id, GameRef);
            rentLogic.ChangeRentDate(Id, RentDate);
            rentLogic.ChangeReturnDate(Id, ReturnDate);
            return RedirectToAction(nameof(GetRentals));
        }

        public IActionResult DeleteRental(int id)
        {
            rentLogic.DeleteRent(id);
            return RedirectToAction(nameof(GetRentals));
        }

        #endregion

        #region People

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

        [HttpGet]
        public IActionResult ModifyPerson(int id)
        {
            return View(personLogic.GetPersonById(id));
        }

        [HttpPost]
        public IActionResult ModifyPerson(int Id, string Name, DateTime BirthDate)
        {
            personLogic.ChangePersonBirthDate(Id, BirthDate);
            personLogic.ChangePersonName(Id, Name);
            return RedirectToAction(nameof(GetPeople));
        }

        public IActionResult DeletePerson(int id)
        {
            personLogic.DeletePerson(id);
            return RedirectToAction(nameof(GetPeople));
        }

        #endregion

        #region Games

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

        [HttpGet]
        public IActionResult ModifyGame(int id)
        {
            return View(gameLogic.GetGameById(id));
        }

        [HttpPost]
        public IActionResult ModifyGame(string Name, string Publisher, DateTime ReleaseDate, int Rating, int Id)
        {
            gameLogic.ChangeGameName(Id, Name);
            gameLogic.ChangeGamePublisher(Id, Publisher);
            gameLogic.ChangeGameReleaseDate(Id, ReleaseDate);
            gameLogic.ChangeGameRating(Id, Rating);
            return RedirectToAction(nameof(GetGames));

        }

        public IActionResult DeleteGame(int id)
        {
            gameLogic.DeleteGame(id);
            return RedirectToAction(nameof(GetGames));
        }

        #endregion
    }
}
