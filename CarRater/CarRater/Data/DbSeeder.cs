using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRater.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRater.Data
{
    public static class DbSeeder
    {
        public static void SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            SeedContacts(context);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            IdentityUser member1 = new IdentityUser
            {
                UserName = "member1@member.com",
                Email = "member1@member.com"
            };
            userManager.CreateAsync(member1, "P@ssword123!").Wait(); // Use wait otherwise code will continuously run and seed wouldnt work (user wouldnt be added)

            IdentityUser contact1 = new IdentityUser
            {
                UserName = "contact1@member.com",
                Email = "contact1@member.com"
            };
            userManager.CreateAsync(contact1, "P@ssword123!").Wait();

            IdentityUser contact2 = new IdentityUser
            {
                UserName = "contact2@member.com",
                Email = "contact2@member.com"
            };
            userManager.CreateAsync(contact2, "P@ssword123!").Wait();

            IdentityUser contact3 = new IdentityUser
            {
                UserName = "contact3@member.com",
                Email = "contact3@member.com"
            };
            userManager.CreateAsync(contact3, "P@ssword123!").Wait();

            IdentityUser contact4 = new IdentityUser
            {
                UserName = "contact4@member.com",
                Email = "contact4@member.com"
            };
            userManager.CreateAsync(contact4, "P@ssword123!").Wait();

            IdentityUser contact5 = new IdentityUser
            {
                UserName = "contact5@member.com",
                Email = "contact5@member.com"
            };
            userManager.CreateAsync(contact5, "P@ssword123!").Wait();
        }
        
        private static void SeedContacts(ApplicationDbContext context)
        {
            context.Database.EnsureCreated(); //Check if database exists, if not it will be created
            //context.Contacts.Add(
            //        new Contact() { Name = "Callum" }
            //    );
            context.SaveChanges();
        }
    }
}
