using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRater.Models;
using Microsoft.AspNetCore.Identity;

/* 
 * This class is to seed the DB incase of any changes giving faster access when logging in for testing
 * Creates 6 accounts, setting their usernames, password and roles (1 admin and 5 regular).
 */

namespace CarRater.Data
{
    public static class DbSeeder
    {
        //Seeds the DB
        public static void SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedContacts(context);
            SeedRoles(roleManager); // Seed role
            SeedUsers(userManager); // Seed account
        }

        //Method used to create 6 users upon boot incase database needs recreating
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            //Create Member1 - Role Administrator
            IdentityUser member1 = new IdentityUser
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com"
            };
            userManager.CreateAsync(member1, "Password123!").Wait(); // Set Password for Seeder account
            userManager.AddToRoleAsync(member1, "Administrator").Wait(); // Set Role of account

            //Create Customer1 - Role Customer
            IdentityUser contact1 = new IdentityUser
            {
                UserName = "Customer1@email.com",
                Email = "Customer1@email.com"
            };
            userManager.CreateAsync(contact1, "Password123!").Wait();// Set Password for Seeder account
            userManager.AddToRoleAsync(contact1, "Customer").Wait(); // Set Role of account

            //Create Customer2 - Role Customer
            IdentityUser contact2 = new IdentityUser
            {
                UserName = "Customer2@email.com",
                Email = "Customer2@email.com"
            };
            userManager.CreateAsync(contact2, "Password123!").Wait();// Set Password for Seeder account
            userManager.AddToRoleAsync(contact2, "Customer").Wait(); // Set Role of account

            //Create Customer3 - Role Customer
            IdentityUser contact3 = new IdentityUser
            {
                UserName = "Customer3@email.com",
                Email = "Customer3@email.com"
            };
            userManager.CreateAsync(contact3, "Password123!").Wait();// Set Password for Seeder account
            userManager.AddToRoleAsync(contact3, "Customer").Wait(); // Set Role of account

            //Create Customer4 - Role Customer
            IdentityUser contact4 = new IdentityUser
            {
                UserName = "Customer4@email.com",
                Email = "Customer4@email.com"
            };
            userManager.CreateAsync(contact4, "Password123!").Wait();// Set Password for Seeder account
            userManager.AddToRoleAsync(contact4, "Customer").Wait(); // Set Role of account

            //Create Customer5 - Role Customer
            IdentityUser contact5 = new IdentityUser
            {
                UserName = "Customer5@email.com",
                Email = "Customer5@email.com"
            };
            userManager.CreateAsync(contact5, "Password123!").Wait();// Set Password for Seeder account
            userManager.AddToRoleAsync(contact5, "Customer").Wait(); // Set Role of account
        }

        /**
         * Create roles for admin and regular to provide different level access
         **/ 
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Create regular user role permissions using IdentityRole
            if (!roleManager.RoleExistsAsync
                ("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Customer";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            // Create administrator role permissions using IdentityRole
            if (!roleManager.RoleExistsAsync
                ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
        
        //Ensures database exists or is created upon boot of server
        private static void SeedContacts(ApplicationDbContext context)
        {
            context.Database.EnsureCreated(); //Check if database exists, if not it will be created
            context.SaveChanges();
        }
    }
}
