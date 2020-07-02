using AutoMapper;
using RentSite.Model.Requests;
using RentSite.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Services
{
    public class RentedResidentialBuildingService : BaseService<Model.RentedResidentalBuilding, ApartmentSearchRequest, Database.RentedResidentialBuilding>
    {
        public RentedResidentialBuildingService(RentSiteContext rentSiteContext, IMapper mapper) : base(rentSiteContext, mapper)
        {
        }
       
        public override Model.RentedResidentalBuilding GetById(int id)
        {
            var entity = _rentSiteContext.RentedResidentialBuilding.Find(id);

            var apartment = _rentSiteContext.ResidentialBuilding.Where(x => x.Id == entity.ResidentialBuildingId).FirstOrDefault();
            var user = _rentSiteContext.User.Where(x => x.Id == entity.UserId).FirstOrDefault();
            if (entity.EndRentalDate == DateTime.Parse("9999-12-31"))   
            {
                Model.RentedResidentalBuilding output = new Model.RentedResidentalBuilding()
                {
                    BeginRentalDate = entity.BeginRentalDate,
                    Description = apartment.Description,
                    EndRentalDate = entity.EndRentalDate,
                    FirstName = user.FirstName,
                    Id = id,
                    LastName = user.LastName,
                    Picture = apartment.Picture,
                    Rented = apartment.Rented,
                    ResidentialBuildingId = apartment.Id,
                    UserId = user.Id
                };
                return output;
            }
            return null;

        }
        public override List<Model.RentedResidentalBuilding> GetAll(ApartmentSearchRequest search)
        {
            var listUser = _rentSiteContext.User.ToList();

            var listApartments = _rentSiteContext.ResidentialBuilding.ToList();

            var listApartmentsUsers = _rentSiteContext.RentedResidentialBuilding.ToList();

            List<Model.RentedResidentalBuilding> output = new List<Model.RentedResidentalBuilding>();

            foreach (var rented in listApartmentsUsers)
            {
                foreach (var user in listUser)
                {
                    if (rented.UserId == user.Id)  
                    {
                        if (rented.EndRentalDate == DateTime.Parse("9999-12-31"))
                            foreach (var apartment in listApartments)
                            {
                                if (search?.CityId.HasValue == true)
                                {
                                    if (apartment.CityId == search.CityId)
                                    {
                                        if (rented.ResidentialBuildingId == apartment.Id && apartment.Rented == true)
                                        {
                                            Model.RentedResidentalBuilding temp = new Model.RentedResidentalBuilding();
                                            temp.Id = rented.Id;
                                            temp.LastName = user.LastName;
                                            temp.FirstName = user.FirstName;
                                            temp.Picture = apartment.Picture;
                                            temp.Rented = apartment.Rented;
                                            temp.UserId = user.Id;
                                            temp.ResidentialBuildingId = apartment.Id;
                                            temp.BeginRentalDate = rented.BeginRentalDate;
                                            temp.EndRentalDate = rented.EndRentalDate;
                                            temp.Description = apartment.Description;
                                            output.Add(temp);
                                        }
                                    }
                                }
                                if (search?.TypeOfResidentialBuildingId.HasValue == true)
                                {
                                    if (apartment.TypeOfResidentialBuildingId == search.TypeOfResidentialBuildingId)
                                    {
                                        if (rented.ResidentialBuildingId == apartment.Id && apartment.Rented == true)
                                        {
                                            Model.RentedResidentalBuilding temp = new Model.RentedResidentalBuilding();
                                            temp.Id = rented.Id;
                                            temp.LastName = user.LastName;
                                            temp.FirstName = user.FirstName;
                                            temp.Picture = apartment.Picture;
                                            temp.Rented = apartment.Rented;
                                            temp.UserId = user.Id;
                                            temp.ResidentialBuildingId = apartment.Id;
                                            temp.BeginRentalDate = rented.BeginRentalDate;
                                            temp.EndRentalDate = rented.EndRentalDate;
                                            temp.Description = apartment.Description;
                                            output.Add(temp);
                                        }
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

