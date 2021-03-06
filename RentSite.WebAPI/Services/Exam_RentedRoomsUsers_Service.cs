﻿using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class Exam_RentedRoomsUsers_Service : BaseService<Model.RentedRooms, Exam_RentedRoomsUsers_FROM_TO, Database.RentedRooms>
    {
        public Exam_RentedRoomsUsers_Service(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
        public override List<Model.RentedRooms> GetAll(Exam_RentedRoomsUsers_FROM_TO search)
        {
            var userList = _rentSiteContext.User.ToList();
            var sobeList = _rentSiteContext.Room.ToList();

            List<Model.RentedRooms> output = new List<Model.RentedRooms>();
            GregorianCalendar calendar = new GregorianCalendar();


            var listaSvihRentanih = _rentSiteContext.RentedRooms.ToList();


            foreach (var rented in listaSvihRentanih)
            {
                foreach (var u in userList)
                {
                    if (rented.UserId == u.Id)
                    {
                        foreach (var room in sobeList)
                        {
                            if (search?.RoomId.HasValue == true && search.RoomId == rented.RoomId && search.RoomId== room.Id )
                            {
                                if (rented.EndRentalDate == DateTime.Parse("9999-12-31"))
                                {
                                    rented.EndRentalDate = DateTime.Now;
                                }
                                var beginRentaldate = rented.BeginRentalDate.ToString();
                                DateTime begin = Convert.ToDateTime(beginRentaldate);
                                var endrentalDate = rented.EndRentalDate.ToString();
                                DateTime end = Convert.ToDateTime(endrentalDate);

                                double numberOfDays = (end - begin).TotalDays;
                                if (numberOfDays == 0 || numberOfDays > 0 && numberOfDays < 1) 
                                {
                                    numberOfDays = 1; 
                                }
                                numberOfDays = Math.Round(numberOfDays, 0);


                                Model.RentedRooms temp = new Model.RentedRooms();
                                temp.Id = rented.Id;
                                temp.LastName = u.LastName;
                                temp.FirstName = u.FirstName;
                                temp.Picture = room.Picture;
                                temp.Rented = room.Rented;
                                temp.UserId = u.Id;
                                temp.RoomId = room.Id;
                                temp.BeginRentalDate = rented.BeginRentalDate;
                                temp.EndRentalDate = rented.EndRentalDate;
                                temp.Description = room.Description;
                                temp.TotalPrice = double.Parse(room.Price.ToString()) * numberOfDays;
                                temp.Price = room.Price;

                                temp.BrojDana = numberOfDays;
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
