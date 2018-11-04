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
            IdentityUser user = new IdentityUser
            {
                UserName = "Callum@email.com",
                Email = "Callum@email.com"
            };

            userManager.CreateAsync(user, "P@ssword123!").Wait(); // Use wait otherwise code will continuously run and seed wouldnt work (user wouldnt be added)
        }

        private static void SeedContacts(ApplicationDbContext context)
        {
            context.Database.EnsureCreated(); //Check if database exists, if not it will be created
            context.Contacts.Add(
                    new Contact() { Name = "Callum" }
                );
            context.SaveChanges();
        }
    }
}
