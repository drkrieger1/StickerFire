
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public UserAuthController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager, ILogger<UserAuthController> logger)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
            _logger = logger;
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
        //[Authorize(Policy = "Admin Only")]
        [HttpGet]
        public IActionResult RegisterAdmin(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //Register Admin user
        //[Authorize(Policy = "Admin Only")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(MegaViewModel avm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = avm.RegisterViewModel.Email, Email = avm.RegisterViewModel.Email };
                var result = await _userManager.CreateAsync(user, avm.RegisterViewModel.Password);

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

        //Login User
        [HttpPost]
        public async Task<IActionResult> Login(MegaViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                //bind viewmodel data to user and sign in.
                var result = await _signInManager.PasswordSignInAsync(lvm.LoginViewModel.Email, lvm.LoginViewModel.Password, lvm.LoginViewModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var userIdentity = new ClaimsIdentity("Registration");

                    var userPrinciple = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(
                        "CookieLogin", userPrinciple,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


    }
}
