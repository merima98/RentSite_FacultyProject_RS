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
    public class CityController : BaseController<Model.City, object>
    {
        public CityController(IService<City, object> service) : base(service)
        {
        }
    }
}