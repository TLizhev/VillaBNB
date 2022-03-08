using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
using VillaBNB.Models;
using VillaBNB.Services;


namespace VillaBNB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IVillaService villaService;
        private readonly IMemoryCache cache;
        public HomeController(ApplicationDbContext db,IVillaService villaService,IMemoryCache cache)
        {
            this.db = db;
            this.villaService = villaService;
            this.cache = cache;
        }


        public IActionResult Index()
        {
            var view = new IndexViewModel()
            {
                VillasCount = this.db.Villas.Count(),
                CitiesCount = this.db.Cities.Count(),
                CountriesCount = this.db.Countries.Count(),
                CategoriesCount = this.db.Categories.Count()
            };

            var latestVillas = this.cache.Get<List<LatestVillaServiceModel>>(WebConstants.Cache.LatestVillaCacheKey);

            if (latestVillas==null)
            {
                latestVillas = this.villaService
                    .Latest().ToList();

                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.cache.Set(WebConstants.Cache.LatestVillaCacheKey, latestVillas, cacheOptions);
            }

            return View(latestVillas);
        }

        public IActionResult AllVillas([FromQuery] AllVillasQueryModel query)
        {
            var queryResult = this.villaService.All(
                query.Name,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllVillasQueryModel.VillasPerPage
                );           

            query.TotalVillas = queryResult.TotalVillas;
            query.Villas = queryResult.Villas;

            return View(query);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
