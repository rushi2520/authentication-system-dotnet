using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticeMVC_DB_Identitty.Models;
using System.Diagnostics;


namespace PracticeMVC_DB_Identitty.Controllers
{
    public class HomeController : Controller
    {
        public readonly UserManager<Users> userManager;
        public readonly SignInManager<Users> signInManager;

        public HomeController(UserManager<Users> userManager,SignInManager<Users> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        //public async Task<IActionResult> Index()
        //{
        //    var user = await userManager.GetUserAsync(User);
        //    return View(user);
        //}

        public async Task<IActionResult> Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                // Check if the 30-second session key exists
                // If it's null, it means the session timed out

                // Check Session
                //if (string.IsNullOrEmpty(HttpContext.Session.GetString("ActiveSession")))
                //👉 This checks:
                //Is session still alive?
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("ActiveSession")))
                {
                    //If Session Expired:
                    await signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Account");
                }
                var currUser = await userManager.GetUserAsync(User);
                if (currUser != null)
                {
                    ViewData["UserName"] = currUser.Name;
                    ViewData["UserPhoto"] = currUser.ProfilePhoto;
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
