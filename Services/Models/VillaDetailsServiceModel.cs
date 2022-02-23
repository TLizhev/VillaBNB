using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Services.Models
{
    public class VillaDetailsServiceModel:VillaServiceModel
    {
        public new int Id { get; set; }

        public new string Name { get; set; }

        public int CategoryId { get; set; }

        public int CityId { get; set; }

        public new string Photo { get; set; }
    }
}
