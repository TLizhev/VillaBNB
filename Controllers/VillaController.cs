using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
using VillaBNB.Data.Models;
using VillaBNB.Models;
using VillaBNB.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using VillaBNB.Services.Models;
using VillaBNB.Services.Models.Owner;
using VillaBNB.Infrastructure.Extensions;

namespace VillaBNB.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IVillaService villaService;
        private readonly IOwnerService owners;
        private readonly IMapper mapper;

        public VillaController(ApplicationDbContext db, IVillaService villas, IMapper mapper, IOwnerService owners)
        {
            this.db = db;
            this.villaService = villas;
            this.mapper = mapper;
            this.owners = owners;
        }

        [HttpGet]
        public IActionResult Add() => View(new VillaViewModel
        {



            Categories = this.GetCategories(),
            Cities = this.GetCities(),
            Countries=this.GetCountries(),
            
        });

        [HttpPost]
        public IActionResult Add(VillaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.villaService.AllCategories();
                return View(model);
            }

            //if (!this.owners.IsOwner(this.User.Id()))
            //{
            //    return RedirectToAction("Home", "Index");
            //}


            var villa = this.villaService.Create(
                //model.OwnerId,
                model.Name,
                model.CityId,
                model.Address,
                model.Bedrooms,
                model.Bathrooms,
                model.PricePerNight,
                model.Photo,
                model.Capacity,
                model.CategoryId
                );

            return RedirectToAction("Index", "Home");
        }



        public IActionResult Edit(int id)
        {
            var villa = this.villaService.Details(id);
            var villaForm = this.mapper.Map<VillaViewModel>(villa);
            villaForm.Categories = this.villaService.AllCategories();
            villaForm.Cities = this.GetCities();


            return View(villaForm);
        }
        [HttpPost]
        public IActionResult Edit(int id, VillaViewModel villa)
        {


            var edited = this.villaService.Edit(
                id,
                villa.Name,
                villa.CityId,
                villa.Bedrooms,
                villa.Bathrooms,
                villa.PricePerNight,
                villa.Photo,
                villa.Capacity
            );

            return RedirectToAction("Index", "Home");

            [HttpGet("{id}")]
           IActionResult Delete(int id)
            {
                var villa = this.villaService.Details(id);
                if (villa==null)
                {
                    return View("NotFound");
                }

                return View(villa);
            }

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.villaService.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            var villa = this.villaService.Details(id);

            return View(villa);
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
