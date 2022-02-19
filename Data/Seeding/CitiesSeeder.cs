using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data.Models;

namespace VillaBNB.Data.Seeding
{
    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext data, IServiceProvider services)
        {
            if (data.Cities.Any())
            {
                return;
            }

            await data.Cities.AddRangeAsync(new[]
              {
                new City {Name = "Varna",CountryId = 1},
                new City {Name = "Burgas",CountryId = 1},
                new City {Name = "Sofia",CountryId = 1},
                new City {Name = "Paris",CountryId = 2},
                new City {Name = "Nice",CountryId = 2},
                new City {Name = "Marsille",CountryId = 2},
            });

            await data.SaveChangesAsync();
        }
    }
}
