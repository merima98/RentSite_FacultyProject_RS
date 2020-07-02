using AutoMapper;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class ApartmentNoFilteredReportService : BaseService<Model.ResidentalBuildingReportNoFiltered, object, Database.RentedResidentialBuilding>
    {
        public ApartmentNoFilteredReportService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }

        public override List<Model.ResidentalBuildingReportNoFiltered> GetAll(object search)
        {
            var listUser = _rentSiteContext.User.ToList();

            var listApartments = _rentSiteContext.ResidentialBuilding.ToList();

            var listApartmentsUsers = _rentSiteContext.RentedResidentialBuilding.ToList();

            List<Model.ResidentalBuildingReportNoFiltered> output = new List<Model.ResidentalBuildingReportNoFiltered>();

            foreach (var rented in listApartmentsUsers)
            {
                foreach (var user in listUser)
                {
                    if (rented.UserId == user.Id)
                    {
                        foreach (var apartment in listApartments)
                        {
                            if (rented.ResidentialBuildingId == apartment.Id)
                            {
                                Model.ResidentalBuildingReportNoFiltered temp = new Model.ResidentalBuildingReportNoFiltered();
                                temp.Id = rented.Id;
                                temp.LastName = user.LastName;
                                temp.FirstName = user.FirstName;
                                temp.Picture = apartment.Picture;
                                temp.UserId = user.Id;
                                temp.ResidentialBuildingId = apartment.Id;
                                temp.BeginRentalDate = rented.BeginRentalDate;
                                temp.BeginRentalDateString = rented.BeginRentalDate?.ToString("dd.MM.yyyy");
                                temp.EndRentalDate = rented.EndRentalDate;
                                temp.EndRentalDateString = rented.EndRentalDate?.ToString("dd.MM.yyyy");
                                temp.Description = apartment.Description;
                                temp.Rented = apartment.Rented;
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
                                    temp.TotalPrice = Math.Round(double.Parse(apartment.Price.ToString()) * numberOfDays, 0);
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
                                    temp.TotalPrice = Math.Round(double.Parse(apartment.Price.ToString()) * numberOfDays, 0);
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
