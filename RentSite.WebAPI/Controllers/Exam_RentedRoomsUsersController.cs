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

    public class Exam_RentedRoomsUsersController : BaseController<Model.RentedRooms, Exam_RentedRoomsUsers_FROM_TO>
    {
        public Exam_RentedRoomsUsersController(IService<RentedRooms, Exam_RentedRoomsUsers_FROM_TO> service) : base(service)
        {
        }
    }
}
