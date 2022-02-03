using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Models
{
    public class AllVillasQueryModel
    {
        public const int VillasPerPage = 3;

        public string Name { get; set; }
        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public int TotalVillas { get; set; }

        public int CurrentPage { get; set; } = 1;

        public VillaSorting Sorting { get; set; }

        public IEnumerable<string> Names { get; set; }

        public IEnumerable<VillaListingModel> Villas { get; set; }
    }
}
