using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Models
{
    public class BookingViewModel
    {
        [Display(Name = "Villa")]
        public int VillaId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalCost { get; set; }

        public int PeopleCount { get; set; }

        public IEnumerable<VillasViewModel> Villas { get; set; }
    }
}
