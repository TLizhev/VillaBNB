using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;

namespace VillaBNB.Services
{
   public class VillaService :IVillaService
    {
        private readonly ApplicationDbContext db;

          
        public VillaService(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
