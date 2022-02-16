using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Models
{
    public class User:IdentityUser
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
