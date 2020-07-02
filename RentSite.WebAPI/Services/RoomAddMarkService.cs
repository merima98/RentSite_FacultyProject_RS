using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RoomAddMarkService : BaseCRUDService<Model.RoomReview, object, Database.RoomReview, Model.RoomReview, object>
    {
        public RoomAddMarkService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
    }
}
