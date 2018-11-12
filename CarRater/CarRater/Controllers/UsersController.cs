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

namespace CarRater.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _users;

        public UsersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _users = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            UserListViewModel userListVM = new UserListViewModel
            {
                Users = await _users.Users.ToListAsync(),
                NumberOfUsers = (await _users.Users.ToListAsync()).Count
            };

            return View(userListVM);
            //return Content((await _users.Users.ToListAsync()).ElementAt(0).UserName);
        }
        
    }
}
