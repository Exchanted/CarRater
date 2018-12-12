using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRater.Models;
using Microsoft.AspNetCore.Identity;

/* Author: Callum Addison 908031
 * This class is to seed the DB incase of any changes giving faster access when logging in for testing
 */

namespace CarRater.Data
{
    public static class DbSeeder
    {
        //Seeds the 6 contacts of the database & ensures database is created or exusts
        public static void SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedContacts(context);
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        //Method used to create 6 users upon boot incase database needs recreating
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            IdentityUser member1 = new IdentityUser
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com"
            };
            userManager.CreateAsync(member1, "Password123!").Wait(); // Use wait otherwise code will continuously run and seed wouldnt work (user wouldnt be added)
            userManager.AddToRoleAsync(member1, "Administrator").Wait();

            IdentityUser contact1 = new IdentityUser
            {
                UserName = "Customer1@email.com",
                Email = "Customer1@email.com"
            };
            userManager.CreateAsync(contact1, "Password123!").Wait();
            userManager.AddToRoleAsync(contact1, "Customer").Wait();

            IdentityUser contact2 = new IdentityUser
            {
                UserName = "Customer2@email.com",
                Email = "Customer2@email.com"
            };
            userManager.CreateAsync(contact2, "Password123!").Wait();
            userManager.AddToRoleAsync(contact2, "Customer").Wait();

            IdentityUser contact3 = new IdentityUser
            {
                UserName = "Customer3@email.com",
                Email = "Customer3@email.com"
            };
            userManager.CreateAsync(contact3, "Password123!").Wait();
            userManager.AddToRoleAsync(contact3, "Customer").Wait();

            IdentityUser contact4 = new IdentityUser
            {
                UserName = "Customer4@email.com",
                Email = "Customer5@email.com"
            };
            userManager.CreateAsync(contact4, "Password123!").Wait();
            userManager.AddToRoleAsync(contact4, "Customer").Wait();

            IdentityUser contact5 = new IdentityUser
            {
                UserName = "Customer5@email.com",
                Email = "Customer5@email.com"
            };
            userManager.CreateAsync(contact5, "Password123!").Wait();
            userManager.AddToRoleAsync(contact5, "Customer").Wait();
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                ("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Customer";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


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
