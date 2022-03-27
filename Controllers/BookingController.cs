﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
using VillaBNB.Data.Models;
using VillaBNB.Models;

namespace VillaBNB.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookingController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Add() => View(new BookingViewModel
        {
            Villas = this.GetVillas(),
        });
        [HttpPost]
        public IActionResult Add(BookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var booking = new Booking
            {
                Id = model.VillaId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TotalPrice = model.PricePerNight*(model.EndDate-model.StartDate).Days,
                VillaId = model.VillaId,
            };

            var bookingList = this.db.Bookings.ToList();

            foreach (var item in bookingList)
            {
                if (item.VillaId == model.VillaId && item.EndDate > model.StartDate)
                {
                    return Json ("Villa does not exist");
                }
            }

            this.db.Bookings.Add(booking);

            this.db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AllBookings()
        {
            var bookings = this.db.Bookings.ToList();
            return View(bookings);
        }


        public IEnumerable<VillasViewModel> GetVillas()
        {
            return this.db.Villas.Select(v => new VillasViewModel
            {
                Id = v.Id,
                Name = v.Name,
            }).ToList();
        }
    }
}
