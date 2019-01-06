using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarRater.Models;

/**
 * Used for CRUD operations to database objects created with DbSet parameter
 **/

namespace CarRater.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Posts DB CRUD
        public DbSet<CarRater.Models.Posts> Posts { get; set; }
        //Comments DB CRUD
        public DbSet<CarRater.Models.Comments> Comments { get; set; }
    }
}