﻿using System;
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

    public class UserApartmentController : BaseController<Model.ResidentialBuilding, ApartmentUserSearchRequest>
    {
        public UserApartmentController(IService<ResidentialBuilding, ApartmentUserSearchRequest> service) : base(service)
        {
        }
    }
}