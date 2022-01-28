﻿using Microsoft.AspNetCore.Mvc;
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

namespace VillaBNB.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IVillaService villaService;
        private readonly IMapper mapper;

        public VillaController(ApplicationDbContext db,IVillaService villas,IMapper mapper)
        {
            this.db = db;
            this.villaService = villas;
            this.mapper = mapper;
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
                return View();
            }

            //var villa = new Villa
            //{
            //    Name = model.Name,
            //    Photo=model.Photo,
            //    Bedrooms = model.Bedrooms,               
            //    Capacity = model.Capacity,
            //    CategoryId=model.CategoryId,
            //    StartDate = model.StartDate,
            //    EndDate = model.EndDate,
            //    Bathrooms = model.Bathrooms,
            //    CityId = model.CityId,                                           
            //};

            //this.db.Villas.Add(villa);

            //this.db.SaveChanges();

            var villa = this.villaService.Create(
                model.Name,
                model.CityId,
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
            var villaForm = this.mapper.Map<VillaServiceModel>(villa);
            //villaForm.Categories = this.villaService.AllCategories()
            return View(villaForm);
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
