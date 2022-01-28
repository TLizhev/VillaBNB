using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Services.Models;

namespace VillaBNB.Services
{
    public interface IVillaService
    {

        VillaServiceModel Details(int villaId);

        int Create(
    string name,
    int cityId,
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
    int capacity,
    int categoryId);

        IEnumerable<VillaServiceModel> AllCategories();
    }
}
