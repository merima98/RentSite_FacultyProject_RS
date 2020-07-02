using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RoomService : BaseCRUDService<Model.Room, RoomSearchRequest, Database.Room, RoomInsertRequest, RoomInsertRequest>

    {
        public RoomService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
        public override List<Model.Room> GetAll(RoomSearchRequest search)
        {
            var query = _rentSiteContext.Set<Database.Room>().AsQueryable();

            if (search?.CityId.HasValue == true)
            {
                query = query.Where(x => x.CityId == search.CityId);
            }

            if (search?.TypeOfRoomId.HasValue == true)
            {
                query = query.Where(x => x.TypeOfRoomId == search.TypeOfRoomId);
            }

            query = query.OrderBy(x => x.CityId);
            var list = query.ToList();

            return _mapper.Map<List<Model.Room>>(list);
        }
        public override Model.Room Insert(RoomInsertRequest request)
        {
            var entity = _mapper.Map<Database.Room>(request);

            _rentSiteContext.Add(entity);
            _rentSiteContext.SaveChanges();

            foreach (var line in request.LineOfTransport)
            {
                Database.LineOfTransportRoom lineRoom = new Database.LineOfTransportRoom
                {
                    LineOfTransportId = line,
                    RoomId = entity.Id
                };
                _rentSiteContext.LineOfTransportRoom.Add(lineRoom);
                _rentSiteContext.SaveChanges();
            }

            return _mapper.Map<Model.Room>(entity);
        }

        public override bool Delete(int id)
        {
            var lineOfTransportRoom = _rentSiteContext.LineOfTransportRoom.Where(l => l.RoomId == id).ToList();
            var rentedRoom = _rentSiteContext.RentedRooms.Where(r => r.RoomId == id).ToList();

            var renterRoomReview = _rentSiteContext.RoomReview.Where(r => r.RoomId == id).ToList();

            foreach (var line in lineOfTransportRoom)
            {
                _rentSiteContext.LineOfTransportRoom.Remove(line);
                _rentSiteContext.SaveChanges();
            }

            foreach (var rented in renterRoomReview)
            {
                _rentSiteContext.RoomReview.Remove(rented);
                _rentSiteContext.SaveChanges();
            }

            foreach (var rented in rentedRoom)
            {
                _rentSiteContext.RentedRooms.Remove(rented);
                _rentSiteContext.SaveChanges();
            }

            var entity = _rentSiteContext.Room.Find(id);
            if (entity!=null)
            {
                _rentSiteContext.Room.Remove(entity);
                _rentSiteContext.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
