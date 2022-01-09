using System.ComponentModel.DataAnnotations;

namespace VillaBNB.Data.Models
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int VillaId { get; set; }

        public virtual Villa Villa { get; set; }
    }
}