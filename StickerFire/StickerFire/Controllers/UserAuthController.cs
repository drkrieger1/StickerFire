
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StickerFire.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Controllers
{
    public class UserAuthController : Controller
    {

        //Dependancy injection for userManager and signInManager
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserAuthController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        //Regular user signup/registration page
        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


    }
}
