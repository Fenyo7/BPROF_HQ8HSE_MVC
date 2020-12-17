using Microsoft.AspNetCore.Mvc;
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
            return View(rentLogic.GetAllRentals());
        }
    }
}
