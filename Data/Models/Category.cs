using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VillaBNB.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Villa> Villas => new HashSet<Villa>();
    }
}