using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data.Models;
using VillaBNB.Models;
using VillaBNB.Services.Models;

namespace VillaBNB.Services
{
    public interface IVillaService
    {

        VillaViewModel Details(int villaId);

        IEnumerable<LatestVillaServiceModel> Latest();

        VillaQueryServiceModel All(
            string name = null,
            string searchTerm = null,
            VillaSorting sorting = VillaSorting.DateCreated,
            int currentPage = 1,
            int villasPerPage = int.MaxValue);

        int Create(
            //int ownerId,
            string name,
            int cityId,
            string address,
            int bedrooms,
            int bathrooms,
            decimal price,
            string imageUrl,
            int capacity,
            int categoryId);

        bool Edit(
            int villaId,
            string name,
            int cityId,
            int bedrooms,
            int bathrooms,
            decimal price,
            string imageUrl,
            int capacity
            );

        bool Delete(int id);

        IEnumerable<CategoryViewModel> AllCategories();
    }
}
