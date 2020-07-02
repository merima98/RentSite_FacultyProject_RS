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

    public class ApartmentsController : BaseCRUDController<Model.ResidentialBuilding, ApartmentSearchRequest, ApartmentsInsertRequest, ApartmentsInsertRequest>
    {
        public ApartmentsController(ICRUDService<ResidentialBuilding, ApartmentSearchRequest, ApartmentsInsertRequest, ApartmentsInsertRequest> service) : base(service)
        {
        }
    }
}