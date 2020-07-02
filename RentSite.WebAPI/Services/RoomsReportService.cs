using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RoomsReportService : BaseService<Model.RoomsReport, YearSearchRequest, Database.RentedRooms>
    {
        public RoomsReportService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        public override List<Model.RoomsReport> GetAll(YearSearchRequest search)
        {
            var listUser = _rentSiteContext.User.ToList();
            var listRooms = _rentSiteContext.Room.ToList();

            List<Model.RoomsReport> output = new List<Model.RoomsReport>();
            GregorianCalendar calendar = new GregorianCalendar();


            var query = _rentSiteContext.RentedRooms.AsQueryable();
            if (search.Year > 0)
            {
                query = query.Where(x => x.Year == search.Year);
            }
            var listRoomsUsers = query.ToList();

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
                                int beginYear = calendar.GetYear(rented.BeginRentalDate ?? DateTime.Now);
                                int endYear = calendar.GetYear(rented.EndRentalDate ?? DateTime.Now);

                                if (beginYear == search.Year && search.Year == endYear)
                                {
                                    Model.RoomsReport temp = new Model.RoomsReport();
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
                                    temp.Year = search.Year;

                                    var beginDate = rented.BeginRentalDate.ToString();
                                    DateTime begin_Date = Convert.ToDateTime(beginDate);
                                    var endDate = rented.EndRentalDate.ToString();
                                    DateTime TodayDate = Convert.ToDateTime(endDate);
                                    double numberOfDays = (TodayDate - begin_Date).TotalDays;
                                    if (numberOfDays == 0 || numberOfDays > 0 && numberOfDays < 1) //needs to pay for min 1 day
                                    {
                                        numberOfDays = 1;
                                    }
                                    temp.TotalPrice = Math.Round(double.Parse(room.Price.ToString()) * numberOfDays, 0);
                                    output.Add(temp);
                                }
                                else if (beginYear == search.Year && endYear != search.Year)
                                {
                                    Model.RoomsReport temp = new Model.RoomsReport();
                                    temp.Id = rented.Id;
                                    temp.LastName = user.LastName;
                                    temp.FirstName = user.FirstName;
                                    temp.Picture = room.Picture;
                                    temp.UserId = user.Id;
                                    temp.RoomId = room.Id;
                                    temp.BeginRentalDate = rented.BeginRentalDate;
                                    temp.BeginRentalDateString = rented.BeginRentalDate?.ToString("dd.MM.yyyy");
                                    temp.EndRentalDate = DateTime.Parse($"{search.Year}-12-31");
                                    temp.EndRentalDateString = rented.EndRentalDate?.ToString("dd.MM.yyyy");
                                    temp.Description = room.Description;
                                    temp.Rented = room.Rented;
                                    temp.Year = search.Year;

                                    var beginDate = rented.BeginRentalDate.ToString();
                                    DateTime begin_Date = Convert.ToDateTime(beginDate);
                                    var endDate = ($"{search.Year}-12-31");
                                    DateTime TodayDate = Convert.ToDateTime(endDate);
                                    double numberOfDays = (TodayDate - begin_Date).TotalDays;
                                    if (numberOfDays == 0) //jer je potrebno platiti barm za jedan dan
                                    {
                                        numberOfDays = 1;
                                    }
                                    temp.TotalPrice = Math.Round(double.Parse(room.Price.ToString()) * numberOfDays, 0);
                                    output.Add(temp);
                                }

                                else if (endYear == search.Year && beginYear != search.Year)
                                {
                                    Model.RoomsReport temp = new Model.RoomsReport();
                                    temp.Id = rented.Id;
                                    temp.LastName = user.LastName;
                                    temp.FirstName = user.FirstName;
                                    temp.Picture = room.Picture;
                                    temp.UserId = user.Id;
                                    temp.RoomId = room.Id;
                                    temp.BeginRentalDate = rented.BeginRentalDate;
                                    temp.BeginRentalDateString = rented.BeginRentalDate?.ToString("dd.MM.yyyy");
                                    temp.EndRentalDate = DateTime.Parse($"{search.Year}-12-31");
                                    temp.EndRentalDateString = rented.EndRentalDate?.ToString("dd.MM.yyyy");
                                    temp.Description = room.Description;
                                    temp.Rented = room.Rented;
                                    temp.Year = search.Year;

                                    var beginDate = ($"{search.Year}-01-01");
                                    DateTime begin_Date = Convert.ToDateTime(beginDate);
                                    var endDate = rented.EndRentalDate.ToString();
                                    DateTime TodayDate = Convert.ToDateTime(endDate);
                                    double numberOfDays = (TodayDate - begin_Date).TotalDays;
                                    if (numberOfDays == 0) //jer je potrebno platiti barm za jedan dan
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
