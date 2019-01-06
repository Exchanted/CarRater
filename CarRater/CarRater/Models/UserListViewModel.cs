using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/**
 * Model for Admin Panel, count of users and a list of users
 **/
namespace CarRater.Models
{
    public class UserListViewModel
    {
        // Obtain number of account on the website
        public int NumberOfUsers { get; set; }

        // Obtain list of users from AspNetUsers
        public List<IdentityUser> Users { get; set; }
    }
}
