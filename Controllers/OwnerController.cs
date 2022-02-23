using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
using VillaBNB.Infrastructure.Extensions;
using VillaBNB.Models;


namespace VillaBNB.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ApplicationDbContext data;

        public OwnerController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeOwnerFormModel owner)
        {
            var userId = this.User.Id();

            var userIdAlreadyOwner = this.data.Owners.Any(o => o.UserId == userId);

            if (userIdAlreadyOwner)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(owner);
            }

            var ownerData = new Owner
            {
                Name = owner.Name,
                PhoneNumber = owner.PhoneNumber,
                UserId = userId,
            };

            this.data.Owners.Add(ownerData);
            this.data.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}
