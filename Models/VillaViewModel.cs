using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VillaBNB.Models
{
    public class VillaViewModel
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }

        public int Capacity { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        [Display(Name = "Price")]
        public decimal PricePerNight { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<CityViewModel>Cities { get; set; }

        public IEnumerable<CountryViewModel> Countries { get; set; }
    }
}
