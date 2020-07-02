using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentSite.WebAPI.Services;

namespace RentSite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarApartmentsUserController : ControllerBase
    {
        private readonly ISimilarApartments _similarApartmentsService;

        public SimilarApartmentsUserController(ISimilarApartments similarApartments)
        {
            _similarApartmentsService = similarApartments;
        }

        [HttpGet]
        public ActionResult<List<Model.ResidentialBuilding>> GetAll(int id)
        {
            return _similarApartmentsService.GetAll(id);
        }
    }
}