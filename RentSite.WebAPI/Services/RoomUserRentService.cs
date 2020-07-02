using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RoomUserRentService : BaseCRUDService<Model.RentedRooms, RoomUserSearchRequest, Database.RentedRooms, RoomUserRent_InsertRequest, RoomUserUpdateRequest>
    {
        public RoomUserRentService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        public override List<Model.RentedRooms> GetAll(RoomUserSearchRequest search)
        {
            var rented = _rentSiteContext.RentedRooms.ToList();
            var output = new List<Database.RentedRooms>();


            foreach (var room in rented)
            {
                if (room.UserId== search.UserId && room.EndRentalDate == DateTime.Parse("9999-12-31"))
                {
                    output.Add(room);
                }
            }

            return _mapper.Map<List<Model.RentedRooms>>(output);
        }
        
    }
}
