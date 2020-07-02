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
    public class SimilarRoomsUserController : ControllerBase
    {
        private readonly ISimilarRooms _similarRoomsService;

        public SimilarRoomsUserController(ISimilarRooms similarRooms)
        {
            _similarRoomsService = similarRooms;
        }

        [HttpGet]
        public ActionResult<List<Model.Room>> GetAll(int id)
        {
            return _similarRoomsService.GetAll(id);
        }
    }
}