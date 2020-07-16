using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class Ispit_SlobodneSobe_OD_DO_Service : BaseService<Model.Room, Ispit_SlobodneSobe_OD_DO_Request, Database.Room>
    {
        public Ispit_SlobodneSobe_OD_DO_Service(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }


        public override List<Model.Room> GetAll(Ispit_SlobodneSobe_OD_DO_Request search)
        {
            var roomsList = _rentSiteContext.Room.ToList();

            if (search.BeginRentalDate <= DateTime.Parse("1753-01-01") || search.BeginRentalDate >= DateTime.Parse("9999-12-31"))
            {
                search.BeginRentalDate = DateTime.Parse("2018-01-01"); //jer je potrebno postaviti na onaj datum koji je trenutno selektovan pri pokretanju
            }

            if (search.EndRentalDate <= DateTime.Parse("1753-01-01") || search.EndRentalDate >= DateTime.Parse("9999-12-31"))
            {
                search.EndRentalDate = DateTime.Parse("2018-01-01");
            }

            List<Model.Room> output = new List<Model.Room>();


            var listaSvihRentanih = _rentSiteContext.RentedRooms.ToList();


            foreach (var slobodneSobe in roomsList)
            {
                if (slobodneSobe.Rented == false) // ako je svakakko slobodan, onda ga dodaj
                {
                    Model.Room temp = new Model.Room();
                    temp.Id = slobodneSobe.Id;
                    temp.Address = slobodneSobe.Address;
                    temp.Description = slobodneSobe.Description;
                    temp.Price = slobodneSobe.Price;
                    temp.Floor = slobodneSobe.Floor;
                    temp.Picture = slobodneSobe.Picture;
                    temp.ArmoredDoor = slobodneSobe.ArmoredDoor;
                    temp.TypeOfHeating = slobodneSobe.TypeOfHeating;
                    temp.Area = slobodneSobe.Area;
                    temp.NewlyBuilt = slobodneSobe.NewlyBuilt;
                    temp.DateOfPublication = slobodneSobe.DateOfPublication;
                    temp.DateOfRenewal = slobodneSobe.DateOfRenewal;
                    temp.CityId = slobodneSobe.CityId;
                    temp.TypeOfRoomId = slobodneSobe.TypeOfRoomId;
                    temp.Rented = slobodneSobe.Rented;
                    output.Add(temp);

                }

                if (slobodneSobe.Rented == true) //ako su zauzeti potrebno je provjeriti kakav im je datum odjave
                {
                    for (int i = 0; i < listaSvihRentanih.Count - 1; i++)
                    {
                        RentedRooms rented = listaSvihRentanih[i];
                        for (int j = 1; j < listaSvihRentanih.Count; j++)
                        {
                            RentedRooms rented1 = listaSvihRentanih[j];
                            if (rented.Id != rented1.Id && rented.RoomId == slobodneSobe.Id && rented.RoomId == rented1.RoomId && rented.EndRentalDate != DateTime.Parse("9999-12-31") && rented1.EndRentalDate != DateTime.Parse("9999-12-31"))
                            {
                                Model.Room temp = new Model.Room();
                                temp.Id = slobodneSobe.Id;
                                temp.Address = slobodneSobe.Address;
                                temp.Description = slobodneSobe.Description;
                                temp.Price = slobodneSobe.Price;
                                temp.Floor = slobodneSobe.Floor;
                                temp.Picture = slobodneSobe.Picture;
                                temp.ArmoredDoor = slobodneSobe.ArmoredDoor;
                                temp.TypeOfHeating = slobodneSobe.TypeOfHeating;
                                temp.Area = slobodneSobe.Area;
                                temp.NewlyBuilt = slobodneSobe.NewlyBuilt;
                                temp.DateOfPublication = slobodneSobe.DateOfPublication;
                                temp.DateOfRenewal = slobodneSobe.DateOfRenewal;
                                temp.CityId = slobodneSobe.CityId;
                                temp.TypeOfRoomId = slobodneSobe.TypeOfRoomId;
                                temp.Rented = slobodneSobe.Rented;
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
