using AutoMapper;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class ApartmentsUserService : BaseService<Model.ResidentialBuilding, object, Database.ResidentialBuilding>
    {
        public ApartmentsUserService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        public override List<Model.ResidentialBuilding> GetAll(object search)
        {
            var list = _rentSiteContext.ResidentialBuilding.ToList();

            var output = new List<Database.ResidentialBuilding>();

            foreach (var x in list)
            {
                if (x.Rented==false)
                {
                    output.Add(x);
                }
            }
            return _mapper.Map<List<Model.ResidentialBuilding>>(output);
        }
    }
}
