using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class UserApartmentService : BaseService<Model.ResidentialBuilding, ApartmentUserSearchRequest, Database.ResidentialBuilding>
    {
        public UserApartmentService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
        public override List<Model.ResidentialBuilding> GetAll(ApartmentUserSearchRequest search)
        {
            var query = _rentSiteContext.Set<Database.ResidentialBuilding>().AsQueryable();

            if (search?.TypeOfResidentialBuildingId.HasValue == true)
            {
                query = query.Where(x => x.TypeOfResidentialBuildingId == search.TypeOfResidentialBuildingId && x.Rented == false);
            }


            if (search?.CityId.HasValue == true)
            {
                query = query.Where(x => x.CityId == search.CityId && x.Rented == false);
            }
            query = query.OrderBy(x => x.CityId);
            var list = query.ToList();
            return _mapper.Map<List<Model.ResidentialBuilding>>(list);

        }
    }
}
