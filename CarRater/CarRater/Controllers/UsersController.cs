using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRater.Data;
using CarRater.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

/**
 * An Admin Panel used to get the number of accounts the website has
 * Also used to list usernames and emails
 * Could be useful for marketing ads, knowing your user count
 **/

namespace CarRater.Controllers
{
    [Authorize(Roles = "Administrator")] //Authorize for Admins only
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _users;

        // Instanciate DBContext and Acquire UserManager to get user information
        public UsersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _users = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            // Create a View Model for users list
            UserListViewModel userListVM = new UserListViewModel
            {
                Users = await _users.Users.ToListAsync(), // Get list of users
                NumberOfUsers = (await _users.Users.ToListAsync()).Count // Get count of accounts
            };

            return View(userListVM);
            //return Content((await _users.Users.ToListAsync()).ElementAt(0).UserName);
        }
        
    }
}
