using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace VillaBNB.Data.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Villa> Villas => new HashSet<Villa>();
        public virtual ICollection<City> Cities => new HashSet<City>();
    }
}