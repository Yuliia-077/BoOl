using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Models
{
    public class BoOlContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var ownerRole = new IdentityRole("Owner");
            if (roleManager.Roles.All(r => r.Name != ownerRole.Name))
            {
                await roleManager.CreateAsync(ownerRole);
            }

            var administratorRole = new IdentityRole("Administrator");
            administratorRole.NormalizedName = "Адміністратор";
            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var technicianRole = new IdentityRole("Technician");
            technicianRole.NormalizedName = "Майстер";
            if (roleManager.Roles.All(r => r.Name != technicianRole.Name))
            {
                await roleManager.CreateAsync(technicianRole);
            }

            var storekeeperRole = new IdentityRole("Storekeeper");
            storekeeperRole.NormalizedName = "Комірник";
            if (roleManager.Roles.All(r => r.Name != storekeeperRole.Name))
            {
                await roleManager.CreateAsync(storekeeperRole);
            }

            var administrator = new User { UserName = "admin@gmail.com", Email = "admin@gmail.com",  };
            if (userManager.Users.All(u => u.Email != administrator.Email))
            {
                await userManager.CreateAsync(administrator, "Admin1!");
                await userManager.AddToRolesAsync(administrator, new[] { ownerRole.Name });
            }
        }
    }
}
