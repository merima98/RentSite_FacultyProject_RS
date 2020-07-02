using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public interface ISimilarApartments
    {
        List<Model.ResidentialBuilding> GetAll(int id);
    }
}
