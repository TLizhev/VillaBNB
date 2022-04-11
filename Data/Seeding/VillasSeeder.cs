using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data.Models;

namespace VillaBNB.Data.Seeding
{
    public class VillasSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext data, IServiceProvider services)
        {
            if (data.Villas.Any())
            {
                return;
            }

            await data.Villas.AddRangeAsync(new[]
             {
                new Villa {Name = "Villa",Capacity = 2,Bedrooms = 2,CategoryId = 1,Bathrooms = 1,CityId = 1,Photo = "https://www.myistria.com/UserDocsImages/app/objekti/795/slika_hd/19082020034916_Villas-near-Rovinj-Villa-Prestige-2.jpg?preset=carousel-1-webp"},

            });

            await data.SaveChangesAsync();
        }
    }
}
