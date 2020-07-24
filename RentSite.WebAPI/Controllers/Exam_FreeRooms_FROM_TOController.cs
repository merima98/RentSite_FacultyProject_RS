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

    public class Exam_FreeRooms_FROM_TOController : BaseController<Model.Room, Exam_FreeRooms_FROM_TO>
    {
        public Exam_FreeRooms_FROM_TOController(Services.IService<Room, Exam_FreeRooms_FROM_TO> service) : base(service)
        {
        }
    }
}
