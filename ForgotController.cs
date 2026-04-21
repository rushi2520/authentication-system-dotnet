using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticeMVC_DB_Identitty.Helper;
using PracticeMVC_DB_Identitty.Models;
using PracticeMVC_DB_Identitty.ViewModels;
using System.Text;
using System.Text.Encodings.Web;

namespace PracticeMVC_DB_Identitty.Controllers
{
    public class ForgotController : Controller
    {
        public readonly UserManager<Users> userManager;
        public readonly SignInManager<Users> signInManager;

        public ForgotController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        public async Task SendForgotPasswordEmail(string email, Users u)
        {
            // Generate the reset password token
            //Generates a secure, unique, time - limited token for the user u
            var token = await userManager.GeneratePasswordResetTokenAsync(u);

            var link = Url.Action("verifyMail", "Forgot", new { Email = email, Token = token }, protocol: HttpContext.Request.Scheme);

            var secureLink = HtmlEncoder.Default.Encode(link);

            string subject = "Password Reset Successfully 🔐";
            string msg = ForgotPasswordTemplate.PasswordChangedTemplate(u.Name, secureLink);
            EmailSender sender = new EmailSender();
            sender.Send(email, subject, msg);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPassword fp)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(fp.Email);
                if (user != null)
                {
                    SendForgotPasswordEmail(fp.Email, user);
                    return RedirectToAction("ForgotPasswordConfirmation");
                }
                else
                {
                    TempData["Message"] = "Email Id does not exists....";
                    return RedirectToAction("ForgotPassword", "ForgotPassword");
                }


            }
            return View(fp);
        }

        public async Task<IActionResult> ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> verifyMail(string email,string token)
        {
            if (email == null || token == null)
            {
                ViewBag.ErrorTitle = "Invalid Password Reset Token";
                ViewBag.ErrorMessage = "The Link is Expired or Invalid";
                return View("Error");
            }
            else
            {
                ResetPasswordViewModels reset = new ResetPasswordViewModels();
                reset.Email = email;
                reset.Token = token;

                return View(reset);
            }
        }

        [HttpPost]
        public async Task<IActionResult> verifyMail(ResetPasswordViewModels res)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(res.Email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, res.Token, res.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ResetPasswordConfirmation");
                    }
                }
                

            }
            return View(res);
        }


        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
