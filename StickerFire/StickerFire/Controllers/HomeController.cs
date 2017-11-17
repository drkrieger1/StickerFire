using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Controllers
{
    public class HomeController : Controller
    {
        //Return home view
        public IActionResult Index()
        {
            return View();
        }

        //Return About us page
        public IActionResult About()
        {
            return View();
        }
    }
}
