using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using RentSite.WebAPI.Services;

namespace RentSite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<IList<Model.User>> GetAll([FromQuery]UsersSearchRequest request)
        {
            return _userService.GetAll(request);
        }

        [HttpGet("{id}")]
        public Model.User GetById(int id)
        {
            return _userService.GetById(id);
        }
        [Authorize(Roles = "1")]   //only Administrator can do this action
        [HttpPost]
        public Model.User Insert(UsersInsertRequest request)  
        {
            return _userService.Insert(request);
        }
        [HttpPut("{id}")]
        public Model.User Update(int id, UsersInsertRequest request)
        {
            return _userService.Update(id, request);
        }

    }
}