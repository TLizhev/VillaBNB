using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VillaBNB.Services.Models.Owner
{
    public interface IOwnerService
    {
        public bool IsOwner(int userId);

        public int IdByUser(int userId);
    }
}
