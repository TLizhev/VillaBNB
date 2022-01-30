using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;
using VillaBNB.Data.Models;
using VillaBNB.Services.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using VillaBNB.Models;

namespace VillaBNB.Services
{
   public class VillaService :IVillaService
    {
        private readonly ApplicationDbContext db;
        private readonly IConfigurationProvider mapper;


        public VillaService(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper.ConfigurationProvider;
        }

        public IEnumerable<VillaServiceModel> AllCategories()
        {
            return this.db.Categories.ProjectTo<VillaServiceModel>(this.mapper).ToList();
        }

        public int Create(string name, int cityId, int bedrooms, int bathrooms, decimal price, string imageUrl, int capacity, int categoryId)
        {
            var villa = new Villa
            {
                Name = name,
                CityId=cityId,
                Bedrooms = bedrooms,
                Bathrooms = bathrooms,
                PricePerNight = price,
                Photo = imageUrl,
                Capacity = capacity,
                CategoryId = categoryId,
            };

            this.db.Villas.Add(villa);
            this.db.SaveChanges();

            return villa.Id;
        }

        public VillaServiceModel Details(int villaId)
        {
            return this.db.Villas
                .Where(v => v.Id == villaId)
                .ProjectTo<VillaServiceModel>(this.mapper)
                .FirstOrDefault();
        }

        public bool Edit(int villaId, string name, int cityId, int bedrooms, int bathrooms, decimal price, string imageUrl, int capacity, int categoryId)
        {
            var villa = this.db.Villas.Find(villaId);

            if (villa==null)
            {
                return false;
            }

            villa.Name = name;
            villa.Photo = imageUrl;
            villa.Capacity = capacity;
            villa.CityId = cityId;
            villa.Bedrooms = bedrooms;
            villa.Bathrooms = bathrooms;
            villa.PricePerNight = price;
            villa.CategoryId = categoryId;

            this.db.SaveChanges();

            return true;
        }
    }
}
