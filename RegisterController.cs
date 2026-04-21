using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticeMVC_DB_Identitty.Helper;
using PracticeMVC_DB_Identitty.Models;
using PracticeMVC_DB_Identitty.ViewModels;
using System.Numerics;
using System.Text.Encodings.Web;


namespace PracticeMVC_DB_Identitty.Controllers
{
    public class RegisterController : Controller
    {
        public readonly SignInManager<Users> signInManager;
        public readonly UserManager<Users> userManager;
        private readonly IWebHostEnvironment relative_path;
        public RegisterController(SignInManager<Users> signInManager, UserManager<Users> userManager, IWebHostEnvironment relative_path)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.relative_path = relative_path;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        public async Task SendRegistertionMail(string email, Users u)
        {
            // For testing without a real SMTP, you can use:
            // System.Diagnostics.Debug.WriteLine(confirmationLink);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(u);

            // 🔗 Create verification link
            var link = Url.Action("ConfirmEmail", "Register", new { Email = email, Token = token }, protocol: HttpContext.Request.Scheme);

            var safelink = HtmlEncoder.Default.Encode(link);

            var subject = "Complete Your Registration -Verify Email";

            var msg = $@"
                <div style=""font-family: Arial; padding:20px;"">
                    <h2>Welcome to Our Platform</h2>

                    <p>Hello {u.Name},</p>

                    <p>Thank you for registering. Please verify your email by clicking the button below:</p>

                    <a href='{safelink}' 
                       style='padding:10px 20px; background:#28a745; color:white; text-decoration:none; border-radius:5px;'>
                       Verify Email
                    </a>

                    <p>If you did not register, ignore this email.</p>

                    <p>Thanks,<br/>Rushikesh Shejul</p>
                </div>";

            EmailSender sender = new EmailSender();
            sender.Send(email, subject, msg);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewmodel res)
        {
            if (ModelState.IsValid)
            {
                string filename = "default-profile.png";
                if (res.Profile_photo != null)
                {
                    filename = Guid.NewGuid + " " + res.Profile_photo.FileName;
                    string folder = Path.Combine(relative_path.WebRootPath, "StoreImg");
                    string ImgPath = Path.Combine(folder, filename);
                    await res.Profile_photo.CopyToAsync(new FileStream(ImgPath, FileMode.Create));
                }

                Users u = new Users()
                {
                    UserName = res.Email,
                    Email = res.Email,
                    Name = res.Name,
                    Surname = res.Surname,
                    DateOfBirth = res.DateOfBirth,
                    Gender = res.gender,
                    NormalizedEmail = res.Email,
                    NormalizedUserName = res.Email,
                    ProfilePhoto = filename,
                    EmailConfirmed = false
                };
                //Step 3: Create User in Database


                //userManager → Identity service
                //CreateAsync → creates user in DB
                //Also:
                //Hashes password 🔐
                //Stores user securely

                //👉 Returns:

                //IdentityResult

                var result = await userManager.CreateAsync(u, res.Password);

                if (result.Succeeded)
                {
                    await SendRegistertionMail(res.Email, u);
                    return View("RegistrationSuccess");
                }
            }
            return View(res);
        }

        public async Task<IActionResult> RegistrationSuccess()
        {
            return View();
        }


        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            if (email == null || token == null)
            {
                return View("Error");
            }
            var user = await userManager.FindByEmailAsync(email);

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View("EmailVerified");
            }
            return View("Error");
        }

        public async Task<IActionResult> EmailVerified()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
