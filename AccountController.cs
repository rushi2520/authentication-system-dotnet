using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeMVC_DB_Identitty.Helper;
using PracticeMVC_DB_Identitty.Models;
using PracticeMVC_DB_Identitty.ViewModels;
using System.Threading.Channels;
using static System.Collections.Specialized.BitVector32;

namespace PracticeMVC_DB_Identitty.Controllers
{
    public class AccountController : Controller
    {
        public readonly SignInManager<Users> signInManager;
        public readonly UserManager<Users> userManager;

        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            var model = new LoginViewmodel
            {
                ReturnUrl = returnUrl ?? Url.Content("~/"),
                // This line gets Google/Facebook from your Program.cs configuration
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewmodel log)
        {
            if (ModelState.IsValid)
            {
                // Attempts to sign in the user using the provided email and password.
                // If credentials are valid, creates an authentication session (cookie).
                // 'RememberMe' keeps the user logged in across sessions.
                // 'false' means account lockout is disabled on failed attempts.
                var user = await signInManager.PasswordSignInAsync(log.Email, log.Password, log.RememberMe, false);
                if (user.Succeeded)
                {
                    // This starts the 30-second timer

                        //If login success:
                        //Creates a session key: "ActiveSession"
                        //Value = "Started"
                        //👉 This is your timer trigger
                    HttpContext.Session.SetString("ActiveSession", "Started");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email Id or Password");
                }
            }
            return View(log);
        }

        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login");
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet] 
        public async Task<IActionResult> ChangePassword()
        {
            if (signInManager.IsSignedIn(User))
            {
                var curr_user = await userManager.Users.FirstOrDefaultAsync(x => x.Email == userManager.GetUserName(User));
                if (curr_user != null)
                {
                    ViewData["Email"] = curr_user.Email;
                }
                return View();
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword ch)
        {
            var login_user = await userManager.Users.FirstOrDefaultAsync(x => x.Email == userManager.GetUserName(User));
            if (ModelState.IsValid)
            {
                var user = await userManager.ChangePasswordAsync(login_user, ch.Current_Password, ch.New_Password);
                if (user.Succeeded)
                {
                    string subject = "Password Changed Successfully 🔐";
                    string msg = ChangePasswordTemplate.PasswordChangedTemplate(login_user.Name);

                    EmailSender sender = new EmailSender();
                    sender.Send(login_user.Email, subject, msg);
                    return RedirectToAction("VerificationChange", "Design");
                }
                if(login_user != null)
                {
                    ViewData["Email"] = login_user.Email;
                }

            }
            return View(ch);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
