using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeMVC_DB_Identitty.Models;

namespace PracticeMVC_DB_Identitty.Controllers
{
    public class CoursesController : Controller
    {
        public readonly PracticeMVCDBContext cour;

        public CoursesController(PracticeMVCDBContext cour)
        {
            this.cour = cour;
        }



        public async Task<IActionResult> Index()
        {
            var courses = await cour.Coursess.ToListAsync();
            return View(courses);
            //List<Courses> cur = new List<Courses>(); 
            //return View(cur);
        }
    }
}
