using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Models;

namespace VillaBNB.Services.Models
{
    public class VillaServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string  CityName { get; set; }

        public string PhotoUrl { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<VillaServiceModel> Categories { get; set; }

    }
}
