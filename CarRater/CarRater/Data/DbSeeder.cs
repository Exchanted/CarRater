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
                UserName = "member1@member.com",
                Email = "member1@member.com"
            };
            userManager.CreateAsync(member1, "P@ssword123!").Wait(); // Use wait otherwise code will continuously run and seed wouldnt work (user wouldnt be added)
            userManager.AddToRoleAsync(member1, "Administrator").Wait();

            IdentityUser contact1 = new IdentityUser
            {
                UserName = "contact1@member.com",
                Email = "contact1@member.com"
            };
            userManager.CreateAsync(contact1, "P@ssword123!").Wait();
            userManager.AddToRoleAsync(contact1, "NormalUser").Wait();

            IdentityUser contact2 = new IdentityUser
            {
                UserName = "contact2@member.com",
                Email = "contact2@member.com"
            };
            userManager.CreateAsync(contact2, "P@ssword123!").Wait();
            userManager.AddToRoleAsync(contact2, "NormalUser").Wait();

            IdentityUser contact3 = new IdentityUser
            {
                UserName = "contact3@member.com",
                Email = "contact3@member.com"
            };
            userManager.CreateAsync(contact3, "P@ssword123!").Wait();
            userManager.AddToRoleAsync(contact3, "NormalUser").Wait();

            IdentityUser contact4 = new IdentityUser
            {
                UserName = "contact4@member.com",
                Email = "contact4@member.com"
            };
            userManager.CreateAsync(contact4, "P@ssword123!").Wait();
            userManager.AddToRoleAsync(contact4, "NormalUser").Wait();

            IdentityUser contact5 = new IdentityUser
            {
                UserName = "contact5@member.com",
                Email = "contact5@member.com"
            };
            userManager.CreateAsync(contact5, "P@ssword123!").Wait();
            userManager.AddToRoleAsync(contact5, "NormalUser").Wait();
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                ("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
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
