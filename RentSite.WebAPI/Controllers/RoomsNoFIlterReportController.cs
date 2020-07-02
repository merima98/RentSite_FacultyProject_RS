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


    public class RoomsNoFIlterReportController : BaseController<Model.RoomsNoFilterReport, object>
    {
        public RoomsNoFIlterReportController(IService<RoomsNoFilterReport, object> service) : base(service)
        {
        }
    }
}