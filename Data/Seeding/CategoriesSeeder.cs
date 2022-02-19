using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data.Models;

namespace VillaBNB.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext data, IServiceProvider services)
        {
            if (data.Categories.Any())
            {
                return;
            }

            await data.Categories.AddRangeAsync(new[]
              {
                new Category { Name = "Urban" },
                new Category { Name = "Village" },
                new Category { Name = "Beach" },
                new Category { Name = "Premium" },
            });

            await data.SaveChangesAsync();
        }
    }
}
