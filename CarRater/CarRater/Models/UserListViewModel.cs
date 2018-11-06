using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRater.Models
{
    public class UserListViewModel
    {
        public int NumberOfUsers { get; set; }
        public List<IdentityUser> Users { get; set; }
    }
}
