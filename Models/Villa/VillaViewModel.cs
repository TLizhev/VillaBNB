using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VillaBNB.Data.Models;

namespace VillaBNB.Models
{
    public class VillaViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Url]
        public string Photo { get; set; }

        public int Capacity { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        [Display(Name= "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Price")]
        public decimal PricePerNight { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<CityViewModel>Cities { get; set; }

        public IEnumerable<CountryViewModel> Countries { get; set; }

        public IEnumerable<Amenity> Amenities { get; set; }
    }
}
