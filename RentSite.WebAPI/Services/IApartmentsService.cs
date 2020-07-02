using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public interface IApartmentsService
    {
        List<Model.ResidentialBuilding> GetAll();
        Model.ResidentialBuilding GetById(int id);
    }
}
