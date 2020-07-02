using AutoMapper;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class ApartmentAddMarkService : BaseCRUDService<Model.ResidentialBuildingReview, object, Database.ResidentialBuildingReview, Model.ResidentialBuildingReview, object>
    {
        public ApartmentAddMarkService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
    }
}
