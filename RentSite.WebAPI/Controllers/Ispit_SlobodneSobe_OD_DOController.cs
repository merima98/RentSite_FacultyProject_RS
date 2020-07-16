using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentSite.Model;
using RentSite.Model.Requests;

namespace RentSite.WebAPI.Controllers
{

    public class Ispit_SlobodneSobe_OD_DOController : BaseController<Model.Room, Ispit_SlobodneSobe_OD_DO_Request>
    {
        public Ispit_SlobodneSobe_OD_DOController(Services.IService<Room, Ispit_SlobodneSobe_OD_DO_Request> service) : base(service)
        {
        }
    }
}
