
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StickerFire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        //Register regular user
        [HttpPost]
        public async Task<IActionResult> Register(MegaViewModel rvm, string returnUrl = null)
            {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = rvm.RegisterViewModel.Email, Email = rvm.RegisterViewModel.Email };
                var result = await _userManager.CreateAsync(user, rvm.RegisterViewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "UserAuth");
        }


        //Admin Registration form
        [HttpGet]
        public IActionResult RegisterAdmin(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //Register Admin user
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterViewModel avm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = avm.Email, Email = avm.Email };
                var result = await _userManager.CreateAsync(user, avm.Password);

                if (result.Succeeded)
                {
                    List<Claim> memberClaims = new List<Claim>();

                    Claim admin = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String);
                    memberClaims.Add(admin);

                    var addClaims = await _userManager.AddClaimsAsync(user, memberClaims);


                    if (addClaims.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        //Login for all users
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var userIdentity = new ClaimsIdentity("Registration");

                    var userPrinciple = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(
                        "MyCookieLogin", userPrinciple,
                            new AuthenticationProperties
                            {
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(45),
                                IsPersistent = false,
                                AllowRefresh = false

                            });

                    return RedirectToAction("Index", "Home");
                }

            }
            string error = "Unable to log you in.  Please try again or contact your system admin.";
            ModelState.AddModelError("", error);
            return View();
        }


    }
}
