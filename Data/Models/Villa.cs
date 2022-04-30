using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Models;

namespace VillaBNB.Data.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public virtual City City { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string Address { get; set; }

        [Url]
        public string Photo { get; set; }

        public int Capacity { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PricePerNight { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual ICollection<Image> Images => new HashSet<Image>();
        public virtual ICollection<Amenity> Amenities => new HashSet<Amenity>();
        public virtual ICollection<Booking> Bookings => new List<Booking>();
    }
}
