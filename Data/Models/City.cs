using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaBNB.Data.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
      [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Villa> Villas => new HashSet<Villa>();
    }
}