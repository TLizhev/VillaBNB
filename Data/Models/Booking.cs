using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Villa))]
        public int VillaId { get; set; }

        public virtual Villa Villa { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
