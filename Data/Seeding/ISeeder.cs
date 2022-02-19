using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext data, IServiceProvider services);

    }
}
