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

    public class TypeOfRoomController : BaseController<Model.TypeOfRoom, object>
    {
        public TypeOfRoomController(IService<TypeOfRoom, object> service) : base(service)
        {
        }
    }
}