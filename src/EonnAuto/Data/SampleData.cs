using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using EonnAuto.Models;
using System.Collections.Generic;

namespace EonnAuto.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            // EONNAUTO CODE
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (!db.Vehicle.Any())
            {
                db.Vehicle.AddRange(
                    new Vehicle
                    {
                        User = mike,
                        Year = 2010,
                        Make = "Acura",
                        Model = "TL",
                        Trim = "Technology",
                        EngSize = "2.4L",
                        Inspection = new List<Inspection>
                    {
                        new Inspection {
                            Date = DateTime.Now,
                        Mileage= 3000,
                        Brake= "Good",
                        Rotor= "Fair",
                        Tire= "Replace",
                        Shock= "N/A",
                        }
                    }

                    },
                new Vehicle
                {
                    User = stephen,
                    Year = 2008,
                    Make = "Honda",
                    Model = "Accord",
                    Trim = "EX",
                    EngSize = "3.6",
                    Inspection = new List<Inspection>
                    {
                        new Inspection {
                            Date = DateTime.Now,
                        Mileage= 12000,
                        Brake= "Fair",
                        Rotor= "Replace",
                        Tire= "Good",
                        Shock= "N/Good",
                        }
                    }

                });
                db.SaveChanges();
            }
        }

    }
}
