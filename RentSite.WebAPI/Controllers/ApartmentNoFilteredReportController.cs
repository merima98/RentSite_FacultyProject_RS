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

    public class ApartmentNoFilteredReportController : BaseController<Model.ResidentalBuildingReportNoFiltered, object>
    {
        public ApartmentNoFilteredReportController(IService<ResidentalBuildingReportNoFiltered, object> service) : base(service)
        {
        }
    }
}