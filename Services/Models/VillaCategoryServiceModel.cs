using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data.Models;

namespace VillaBNB.Services.Models
{
    public class VillaCategoryServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
