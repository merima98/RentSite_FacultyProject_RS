using AutoMapper;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RoomsNoFilterReportService : BaseService<Model.RoomsNoFilterReport, object, Database.RentedRooms>
    {
        public RoomsNoFilterReportService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        public override List<Model.RoomsNoFilterReport> GetAll(object search)
        {
            var listUser = _rentSiteContext.User.ToList();

            var listRooms= _rentSiteContext.Room.ToList();

            var listRoomsUsers = _rentSiteContext.RentedRooms.ToList();

            List<Model.RoomsNoFilterReport> output = new List<Model.RoomsNoFilterReport>();


            foreach (var rented in listRoomsUsers)
            {
                foreach (var user in listUser)
                {
                    if (rented.UserId == user.Id)
                    {
                        foreach (var room in listRooms)
                        {
                            if (rented.RoomId == room.Id)
                            {
                                Model.RoomsNoFilterReport temp = new Model.RoomsNoFilterReport();
                                temp.Id = rented.Id;
                                temp.LastName = user.LastName;
                                temp.FirstName = user.FirstName;
                                temp.Picture = room.Picture;
                                temp.UserId = user.Id;
                                temp.RoomId = room.Id;
                                temp.BeginRentalDate = rented.BeginRentalDate;
                                temp.BeginRentalDateString = rented.BeginRentalDate?.ToString("dd.MM.yyyy");
                                temp.EndRentalDate = rented.EndRentalDate;
                                temp.EndRentalDateString = rented.EndRentalDate?.ToString("dd.MM.yyyy");
                                temp.Description = room.Description;
                                temp.Rented = room.Rented;
                                temp.Year = rented.Year;

                                if (temp.EndRentalDate == DateTime.Parse("9999-12-31"))
                                {
                                    var beginDate = rented.BeginRentalDate.ToString();
                                    DateTime begin_Date = Convert.ToDateTime(beginDate);
                                    DateTime TodayDate = DateTime.Now;
                                    double numberOfDays = (TodayDate - begin_Date).TotalDays;
                                    if (numberOfDays == 0) //needs to pay for min 1 day
                                    {
                                        numberOfDays = 1;
                                    }
                                    temp.TotalPrice = Math.Round(double.Parse(room.Price.ToString()) * numberOfDays, 0);
                                    output.Add(temp);

                                }
                                else
                                {
                                    var beginDate = rented.BeginRentalDate.ToString();
                                    DateTime begin_Date = Convert.ToDateTime(beginDate);
                                    var endDate = rented.BeginRentalDate.ToString();
                                    DateTime end_date = Convert.ToDateTime(endDate);
                                    double numberOfDays = (end_date - begin_Date).TotalDays;
                                    if (numberOfDays == 0)
                                    {
                                        numberOfDays = 1;
                                    }
                                    temp.TotalPrice = Math.Round(double.Parse(room.Price.ToString()) * numberOfDays, 0);
                                    output.Add(temp);

                                }
                            }
                        }
                    }
                }
            }

            return output;
        }



    }
}
