using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RentedRoomUserService : BaseService<Model.RentedRooms, RoomUserSearchRequest, Database.RentedRooms>
    {
        public RentedRoomUserService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        public override Model.RentedRooms GetById(int id)
        {
            var entity = _rentSiteContext.RentedRooms.Find(id);

            var room = _rentSiteContext.Room.Where(x => x.Id == entity.RoomId).FirstOrDefault();
            var user = _rentSiteContext.User.Where(x => x.Id == entity.UserId).FirstOrDefault();

            Model.RentedRooms output = new Model.RentedRooms()
            {
                BeginRentalDate = entity.BeginRentalDate,
                Description = room.Description,
                EndRentalDate = entity.EndRentalDate,
                FirstName = user.FirstName,
                Id = id,
                LastName = user.LastName,
                Picture = room.Picture,
                Rented = room.Rented,
                RoomId = room.Id,
                UserId = user.Id

            };


            return output;
        }

        public override List<Model.RentedRooms> GetAll(RoomUserSearchRequest search)
        {
            var listRooms = _rentSiteContext.Room.ToList();

            var listRoomsUsers = _rentSiteContext.RentedRooms.ToList();

            User user = _rentSiteContext.User.Find(search.UserId);

            List<Model.RentedRooms> output = new List<Model.RentedRooms>();

            foreach (var rented in listRoomsUsers)
            {
                foreach (var room in listRooms)
                {
                    if(user!=null)
                    if (rented.EndRentalDate == DateTime.Parse("9999-12-31") && rented.UserId == user.Id && rented.RoomId == room.Id && room.Rented == true)
                    {
                        if (search?.CityId.HasValue == true)
                        {
                            if (room.CityId == search.CityId)
                            {
                                Model.RentedRooms temp = new Model.RentedRooms();
                                temp.Id = rented.Id;
                                temp.LastName = user.LastName;
                                temp.FirstName = user.FirstName;
                                temp.Picture = room.Picture;
                                temp.Rented = room.Rented;
                                temp.UserId = user.Id;
                                temp.RoomId = room.Id;
                                temp.BeginRentalDate = rented.BeginRentalDate;
                                temp.EndRentalDate = rented.EndRentalDate;
                                temp.Description = room.Description;
                                output.Add(temp);
                            }
                        }
                        if (search?.TypeOfRoomId.HasValue == true)
                        {
                            if (room.TypeOfRoomId == search.TypeOfRoomId)
                            {
                                Model.RentedRooms temp = new Model.RentedRooms();
                                temp.Id = rented.Id;
                                temp.LastName = user.LastName;
                                temp.FirstName = user.FirstName;
                                temp.Picture = room.Picture;
                                temp.Rented = room.Rented;
                                temp.UserId = user.Id;
                                temp.RoomId = room.Id;
                                temp.BeginRentalDate = rented.BeginRentalDate;
                                temp.EndRentalDate = rented.EndRentalDate;
                                temp.Description = room.Description;
                                output.Add(temp);
                            }
                        }
                    }

                }
            }
            return output;
        }
    }
}
