using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
using VillaBNB.Models;

namespace VillaBNB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            var view = new IndexViewModel()
            {
                VillasCount = this.db.Villas.Count(),
                CitiesCount= this.db.Cities.Count(),
                CountriesCount=this.db.Countries.Count(),
                CategoriesCount=this.db.Categories.Count()
            };
            return View(view);
        }

        public IActionResult AllVillas()
        {
            var villas = this.db
                .Villas
                .OrderByDescending(v => v.Id)
                .Select(v => new VillaListingModel
                {
                    Id = v.Id,
                    Name = v.Name,
                    Category = v.Category.Name,
                    Photo = v.Photo,
                })                
                .ToList();
            return View(villas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
