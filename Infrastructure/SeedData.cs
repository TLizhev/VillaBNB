namespace CarRentingSystem.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using VillaBNB.Data;
    using VillaBNB.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedCountries(services);
            SeedCities(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Urban" },
                new Category { Name = "Village" },
                new Category { Name = "Beach" },
                new Category { Name = "Premium" },
                new Category {Name = "Mountain"},
            });

            data.SaveChanges();
        }

        private static void SeedCountries(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Countries.Any())
            {
                return;
            }

            data.Countries.AddRange(new[]
            {
                new Country {Name = "Bulgaria"},
                new Country {Name = "France"},
            });

            data.SaveChanges();
        }

        private static void SeedCities(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Cities.Any())
            {
                return;
            }

            data.Cities.AddRange(new[]
            {
                new City {Name = "Varna",CountryId = 1},
                new City {Name = "Burgas",CountryId = 1},
                new City {Name = "Sofia",CountryId = 1},
                new City {Name = "Paris",CountryId = 2},
                new City {Name = "Nice",CountryId = 2},
                new City {Name = "Marsille",CountryId = 2},
            });

            data.SaveChanges();
        }



        

    }
}
