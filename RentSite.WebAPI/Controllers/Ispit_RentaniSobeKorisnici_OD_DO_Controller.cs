using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentSite.Model;
using RentSite.Model.Requests;
using RentSite.WebAPI.Services;

namespace RentSite.WebAPI.Controllers
{

    public class Ispit_RentaniSobeKorisnici_OD_DO_Controller : BaseController<Model.RentedRooms, Ispit_RentaniSobeKorisnici_OD_DO_Request>
    {
        public Ispit_RentaniSobeKorisnici_OD_DO_Controller(IService<RentedRooms, Ispit_RentaniSobeKorisnici_OD_DO_Request> service) : base(service)
        {
        }
    }
}
