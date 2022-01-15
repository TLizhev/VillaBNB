using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
using VillaBNB.Data.Models;
using VillaBNB.Models;

namespace VillaBNB.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext db;

        public VillaController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var view = new VillaViewModel();
            return View(view);
        }
        [HttpPost]
        public IActionResult Index(VillaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            var villa = new Villa
            {
                Name = model.Name,
                Bedrooms = model.Bedrooms,               
                Capacity = model.Capacity,
                CategoryId=model.CategoryId,

                
               
                

            };

            this.db.Villas.Add(villa);
            this.db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
