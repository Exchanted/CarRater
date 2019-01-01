using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRater.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarRater.Controllers
{
    [Authorize] // Require a user to login when visitting the page
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View(RedirectToAction("", "Posts/Index"));
        }
        
        [AllowAnonymous]
        public IActionResult Splash()
        {
            return View("Splash");
        }

        [AllowAnonymous] // Overwritten to allow the view of non-logged in users
        public IActionResult About() 
        {
            ViewData["Message"] = "About";

            return View();
        }

        [AllowAnonymous] // Overwritten to allow the view of non-logged in users
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        
        [Authorize(Roles = "Administrator")]
        public IActionResult Admin() //Add if user is authenticated as role admin then display this
        {
            return RedirectToAction("", "Users/Index");
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
