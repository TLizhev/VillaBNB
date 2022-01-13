using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Models
{
    public class VillaViewModel
    {
        public string Name { get; set; }

        //public int CategoryId { get; set; }

        //public int CityId { get; set; }

        //public int CountryId { get; set; }

        public int Capacity { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PricePerNight { get; set; }
    }
}
