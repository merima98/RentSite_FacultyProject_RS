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

    public class LineOfTransportController : BaseController<Model.LineOfTransport, object>
    {
        public LineOfTransportController(IService<LineOfTransport, object> service) : base(service)
        {
        }
    }
}