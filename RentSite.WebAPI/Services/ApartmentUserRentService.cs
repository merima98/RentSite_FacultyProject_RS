using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class ApartmentUserRentService : BaseCRUDService<Model.RentedResidentalBuilding, ApartmentUserSearchRequest, Database.RentedResidentialBuilding, ApartmentUserRent_InsertRequest, ApartmentUserUpdateRequest>
    {
        public ApartmentUserRentService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
        public override List<Model.RentedResidentalBuilding> GetAll(ApartmentUserSearchRequest search)
        {

            var rented = _rentSiteContext.RentedResidentialBuilding.ToList();
            var output = new List<Database.RentedResidentialBuilding>();

            foreach (var apartment in rented)
            {
                if (apartment.UserId==search.UserId && apartment.EndRentalDate == DateTime.Parse("9999-12-31"))
                {
                    output.Add(apartment);
                }
            }

            return _mapper.Map<List<Model.RentedResidentalBuilding>>(output);
        }
    }
}
