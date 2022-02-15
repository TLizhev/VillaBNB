using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Services.Models;

namespace VillaBNB.Models
{
    public class VillaDetailsModel : VillaServiceModel
    {
        public new int Id { get; set; }

        public new string Name { get; set; }

        public new string CityName { get; set; }

        public new string Photo { get; set; }

        public new string CategoryName { get; set; }
    }
}
