using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;

namespace VillaBNB.Services.Models.Owner
{
    public class OwnerService /*: /*IOwnerService*/
    {

        private readonly ApplicationDbContext data;

        public OwnerService(ApplicationDbContext data)
        {
            this.data = data;
        }

        //public int IdByUser(int userId)
        //{
        //    return this.data.Owners.Where(o => o.UserId==userId).Select(o=>o.Id).First();
        //}

        //public bool IsOwner(int userId)
        //{
        //    return this.data.Owners.Any(o => o.UserId == userId);
        //}
    }
}
