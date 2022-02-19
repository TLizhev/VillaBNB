using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data.Models;

namespace VillaBNB.Data.Seeding
{
    public class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext data, IServiceProvider services)
        {
            if (data.Countries.Any())
            {
                return;
            }

            await data.Countries.AddRangeAsync(new[]
             {
                new Country {Name = "Bulgaria"},
                new Country {Name = "France"},
            });

            await data.SaveChangesAsync();
        }
    }
}
