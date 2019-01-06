using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRater.Models;
using Microsoft.AspNetCore.Authorization;

/**
 * Handle homepage, splash entry page and navbar operations
 **/

namespace CarRater.Controllers
{
    [Authorize] // Require a user to login when visitting the page
    public class HomeController : Controller
    {
        [Authorize] // Require a user to login when visitting the page
        public IActionResult Index()
        {
            return View(RedirectToAction("", "Posts/Index"));
        }
        
        [AllowAnonymous] // Overwritten to allow the view of non-logged in users
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
            ViewData["Message"] = "Contact";

            return View();
        }
        
        [Authorize(Roles = "Administrator")]// Require a user to login as admin when visitting the page
        public IActionResult Admin() //Add if user is authenticated as role admin then display this
        {
            return RedirectToAction("", "Users/Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
