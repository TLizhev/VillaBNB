using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VillaBNB.Data.Models;
using VillaBNB.Models;
using VillaBNB.Services;
using VillaBNB.Services.Models;

namespace VillaBNB.Infrastructurre
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Villa, VillaViewModel>();

            this.CreateMap<Villa, VillaServiceModel>();

            this.CreateMap<Villa, VillaCategoryServiceModel>();

            this.CreateMap<Category, CategoryViewModel>();

            this.CreateMap<VillaViewModel, VillaCategoryServiceModel>();

            this.CreateMap<Villa, LatestVillaServiceModel>();

            this.CreateMap<VillaViewModel, LatestVillaServiceModel>();

            this.CreateMap<VillaViewModel, VillaServiceModel>();

            this.CreateMap<BookingViewModel, Booking>();

        }
    }
}
