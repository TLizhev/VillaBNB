using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Services.Models;

namespace VillaBNB.Models
{
    public class VillaQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int VillasPerPage { get; set; }

        public int TotalVillas { get; set; }

        public IEnumerable<VillaServiceModel> Villas { get; set; }
    }
}
