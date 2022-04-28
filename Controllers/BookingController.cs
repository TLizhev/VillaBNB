using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

            var httpContext = new HttpContextAccessor().HttpContext;

            if (!ModelState.IsValid)
            {
                return View();
            }
            var booking = new Booking
            {
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

            if (booking.TotalPrice==0)
            {
                return Json("Cannot book villa for less than 2 days");
            }

            this.db.Bookings.Add(booking);

            this.db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AllBookings()
        {
            var bookings = GetBookings();
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

        public IEnumerable<BookingViewModel> GetBookings()
        {
            return this.db.Bookings.Select(v => new BookingViewModel
            {
                VillaName = v.Villa.Name,
                BookingOwner = HttpContext.User.Identity.ToString(),
                VillaId = v.VillaId,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                TotalCost = v.TotalPrice,
            }).ToList();
        }

        public IEnumerable<Villa> GetAllVillas()
        {
            return this.db.Villas.Select(x => new Villa
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
        }
    }
}
