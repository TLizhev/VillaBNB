using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
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
    }
}
