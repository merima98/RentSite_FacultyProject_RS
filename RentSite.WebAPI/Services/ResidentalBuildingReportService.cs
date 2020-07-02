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
    public class ResidentalBuildingReportService : BaseService<Model.ResidentalBuildingReport, YearSearchRequest, Database.RentedResidentialBuilding>
    {
        public ResidentalBuildingReportService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
        public override List<Model.ResidentalBuildingReport> GetAll(YearSearchRequest search)
        {
            var listUser = _rentSiteContext.User.ToList();

            var listApartments = _rentSiteContext.ResidentialBuilding.ToList();
           

            List<Model.ResidentalBuildingReport> output = new List<Model.ResidentalBuildingReport>();

            GregorianCalendar calendar = new GregorianCalendar();
    
            var query = _rentSiteContext.RentedResidentialBuilding.AsQueryable();
            if (search.Year>0)
            {
                query = query.Where(x => x.Year == search.Year);
            }
            var listApartmentsUsers = query.ToList();
            foreach (var rented in listApartmentsUsers)
            {
                foreach (var user in listUser)
                {
                    if (rented.UserId == user.Id)
                    {
                        foreach (var apartment in listApartments)
                        {
                            if (rented.ResidentialBuildingId== apartment.Id)
                            {
                                int beginYear = calendar.GetYear(rented.BeginRentalDate ?? DateTime.Now);
                                int endYear = calendar.GetYear(rented.EndRentalDate ?? DateTime.Now);
                                if (beginYear == search.Year && search.Year == endYear)
                                {
                                    Model.ResidentalBuildingReport temp = new Model.ResidentalBuildingReport();
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
                                    temp.TotalPrice = Math.Round(double.Parse(apartment.Price.ToString()) * numberOfDays, 0);
                                    output.Add(temp);
                                }
                                else if (beginYear == search.Year && endYear != search.Year)
                                {
                                    Model.ResidentalBuildingReport temp = new Model.ResidentalBuildingReport();
                                    temp.Id = rented.Id;
                                    temp.LastName = user.LastName;
                                    temp.FirstName = user.FirstName;
                                    temp.Picture = apartment.Picture;
                                    temp.UserId = user.Id;
                                    temp.ResidentialBuildingId = apartment.Id;
                                    temp.BeginRentalDate = rented.BeginRentalDate;
                                    temp.BeginRentalDateString = rented.BeginRentalDate?.ToString("dd.MM.yyyy");
                                    temp.EndRentalDate = DateTime.Parse($"{search.Year}-12-31");
                                    temp.EndRentalDateString = rented.EndRentalDate?.ToString("dd.MM.yyyy");
                                    temp.Description = apartment.Description;
                                    temp.Rented = apartment.Rented;
                                    temp.Year = search.Year;

                                    var beginDate = rented.BeginRentalDate.ToString();
                                    DateTime begin_Date = Convert.ToDateTime(beginDate);
                                    var endDate = ($"{search.Year}-12-31");
                                    DateTime TodayDate = Convert.ToDateTime(endDate);
                                    double numberOfDays = (TodayDate - begin_Date).TotalDays;
                                    if (numberOfDays == 0) //needs to pay for min 1 day
                                    {
                                        numberOfDays = 1;
                                    }
                                    temp.TotalPrice = Math.Round(double.Parse(apartment.Price.ToString()) * numberOfDays, 0);
                                    output.Add(temp);
                                }
                                else if (endYear == search.Year && beginYear != search.Year)
                                {
                                    Model.ResidentalBuildingReport temp = new Model.ResidentalBuildingReport();
                                    temp.Id = rented.Id;
                                    temp.LastName = user.LastName;
                                    temp.FirstName = user.FirstName;
                                    temp.Picture = apartment.Picture;
                                    temp.UserId = user.Id;
                                    temp.ResidentialBuildingId = apartment.Id;
                                    temp.BeginRentalDate = rented.BeginRentalDate;
                                    temp.BeginRentalDateString = rented.BeginRentalDate?.ToString("dd.MM.yyyy");
                                    temp.EndRentalDate = DateTime.Parse($"{search.Year}-12-31");
                                    temp.EndRentalDateString = rented.EndRentalDate?.ToString("dd.MM.yyyy");
                                    temp.Description = apartment.Description;
                                    temp.Rented = apartment.Rented;
                                    temp.Year = search.Year;

                                    var beginDate = ($"{search.Year}-01-01");
                                    DateTime begin_Date = Convert.ToDateTime(beginDate);
                                    var endDate = rented.EndRentalDate.ToString();
                                    DateTime TodayDate = Convert.ToDateTime(endDate);
                                    double numberOfDays = (TodayDate - begin_Date).TotalDays;
                                    if (numberOfDays == 0) //needs to pay for min 1 day
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
