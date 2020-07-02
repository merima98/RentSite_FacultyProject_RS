using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RoomUserService : BaseService<Model.Room, RoomUserSearchRequest, Database.Room>
    {
        public RoomUserService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        
        public override List<Model.Room> GetAll(RoomUserSearchRequest search)
        {
            var query = _rentSiteContext.Set<Database.Room>().AsQueryable();

            if (search?.TypeOfRoomId.HasValue == true)
            {
                query = query.Where(x => x.TypeOfRoomId == search.TypeOfRoomId && x.Rented == false);
            }

            if (search?.CityId.HasValue == true)
            {
                query = query.Where(x => x.CityId == search.CityId && x.Rented == false);
            }

            query = query.OrderBy(x => x.CityId);
            var list = query.ToList();
            return _mapper.Map<List<Model.Room>>(list);
        }
    }
}
