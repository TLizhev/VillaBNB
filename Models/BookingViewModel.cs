using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Models
{
    public class BookingViewModel
    {
        public int VillaId { get; set; }

        [Required]
        [Display(Name = "Villa")]
        public string VillaName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }

        [Display(Name = "Number of guests")]
        public int PeopleCount { get; set; }

        public IEnumerable<VillasViewModel> Villas { get; set; }
    }
}
