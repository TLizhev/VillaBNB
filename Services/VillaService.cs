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

        public VillaQueryServiceModel All(string name = null, string searchTerm = null, VillaSorting sorting = VillaSorting.DateCreated, int currentPage = 1, int villasPerPage = int.MaxValue)
        {
            var villasQuery = this.db.Villas.Where(v=>v.CityId!=0);

            villasQuery = sorting switch
            {
                VillaSorting.DateCreated => villasQuery.OrderByDescending(v => v.Name),
                VillaSorting.Category => villasQuery.OrderByDescending(v => v.Category),
                VillaSorting.City => villasQuery.OrderByDescending(v => v.City),
                _ => throw new NotImplementedException()
            };

            var totalVillas = villasQuery.Count();

            var villas = GetVillas(villasQuery.Skip((currentPage-1)*villasPerPage).Take(villasPerPage));

            return new VillaQueryServiceModel
            {
                TotalVillas = totalVillas,
                CurrentPage = currentPage,
                VillasPerPage = villasPerPage,
                Villas = villas,
            };
        }

        public IEnumerable<CategoryViewModel> AllCategories()
        {            

            return this.db.Categories.ProjectTo<CategoryViewModel>(this.mapper).ToList();
        }

        public int Create(/*int ownerId,*/string name, int cityId,string address, int bedrooms, int bathrooms, decimal price, string imageUrl, int capacity, int categoryId)
        {
            var villa = new Villa
            {
                //OwnerId = ownerId,
                Name = name,
                CityId=cityId,
                Address=address,
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

        public VillaViewModel Details(int villaId)
        {
            var result =  this.db.Villas
                .Where(v => v.Id == villaId)
                .ProjectTo<VillaViewModel>(this.mapper)
                .FirstOrDefault();

            return result;
        }

        private IEnumerable<VillaServiceModel> GetVillas(IQueryable<Villa> villaQuery)
        {
          return  villaQuery.ProjectTo<VillaServiceModel>(this.mapper).ToList();
        }

        public bool Edit(int villaId, string name, int cityId, int bedrooms, int bathrooms, decimal price, string imageUrl, int capacity)
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
            ;

            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<LatestVillaServiceModel> Latest()
        {
            return this.db.Villas.OrderByDescending(x => x.Id).ProjectTo<LatestVillaServiceModel>(this.mapper).Take(5).ToList();
        }
    }
}
