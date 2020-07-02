using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentSite.Model;
using RentSite.WebAPI.Services;

namespace RentSite.WebAPI.Controllers
{

    public class ApartmentsUserController : BaseController<Model.ResidentialBuilding, object>
    {
        public ApartmentsUserController(IService<ResidentialBuilding, object> service) : base(service)
        {
        }
    }
}