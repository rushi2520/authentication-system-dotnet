using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeMVC_DB_Identitty.Models;
using PracticeMVC_DB_Identitty.ViewModels;

namespace PracticeMVC_DB_Identitty.Controllers
{
    public class StudentController : Controller
    {
        public readonly PracticeMVCDBContext db;
        public readonly UserManager<Users> userManager;


        public StudentController(PracticeMVCDBContext db)
        {
            this.db = db;
        }

       
        public async Task<IActionResult> Index()
        {
            List<Student> st = new List<Student>();
            List<Courses> cou = new List<Courses>();
            return View(cou);
        }
    }
}
