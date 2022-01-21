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
        public IActionResult Add() => View(new VillaViewModel
        {
            Categories = this.GetCategories(),
            Cities = this.GetCities(),
            
        });

        [HttpPost]
        public IActionResult Add(VillaViewModel model)
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
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Bathrooms = model.Bathrooms,
                CityId = model.CityId,                                           
            };

            this.db.Villas.Add(villa);
            
            this.db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }



        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id, VillaViewModel villa)
        {
            return View();
        }


        private IEnumerable<CategoryViewModel> GetCategories()
        {
           return this.db.Categories.Select(c => new CategoryViewModel
            {
               Id=c.Id,
               Name = c.Name
            }).ToList();
        }

        private IEnumerable<CityViewModel> GetCities()
        {
            return this.db.Cities.Select(c => new CityViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        private IEnumerable<CountryViewModel> GetCountries()
        {
            return this.db.Countries.Select(c => new CountryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
