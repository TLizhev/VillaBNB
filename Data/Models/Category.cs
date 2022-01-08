using System.Collections;
using System.Collections.Generic;

namespace VillaBNB.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Villa> Villas => new HashSet<Villa>();
    }
}