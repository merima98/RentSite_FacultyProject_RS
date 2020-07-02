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


    public class ApartmentReviewController : BaseCRUDController<Model.ResidentialBuildingReview, object, Model.ResidentialBuildingReview, object>
    {
        public ApartmentReviewController(ICRUDService<ResidentialBuildingReview, object, ResidentialBuildingReview, object> service) : base(service)
        {
        }
    }
}