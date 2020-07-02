using AutoMapper;
using RentSite.Model;
using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.ResidentialBuilding, Model.ResidentialBuilding>();
            CreateMap<Database.User, Model.User>();
            CreateMap<Model.User, Database.User>();
            CreateMap<UsersInsertRequest, Database.User>().ForMember(c => c.TypeOfUser, option => option.Ignore())
                                                          .ForMember(c => c.RentedResidentialBuilding, option => option.Ignore())
                                                          .ForMember(c => c.RentedRooms, option => option.Ignore());
            CreateMap<Database.User, UsersInsertRequest>();
            CreateMap<Database.TypeOfUser, Model.TypeOfUser>();
            CreateMap<Model.TypeOfUser, Database.TypeOfUser>();
            CreateMap<Database.AttractiveObjects, Model.AttractiveObjects>();
            CreateMap<Model.AttractiveObjects, Database.AttractiveObjects>();
            CreateMap<Database.City, Model.City>();
            CreateMap<Database.LineOfTransport, Model.LineOfTransport>();
            CreateMap<Database.TypeOfResidentialBuilding, Model.TypeOfResidentialBuilding>();
            CreateMap<Database.LineOfTransportResidentialBuilding, Model.LineOfTransportResidentialBuilding>();
            CreateMap<Model.City, Database.City>();
            CreateMap<Model.LineOfTransport, Database.LineOfTransport>();
            CreateMap<Model.TypeOfResidentialBuilding, Database.TypeOfResidentialBuilding>();
            CreateMap<Model.LineOfTransportResidentialBuilding, Database.LineOfTransportResidentialBuilding>();
            CreateMap<ApartmentsInsertRequest, Database.ResidentialBuilding>();
            CreateMap<Database.Room, Model.Room>();
            CreateMap<RoomInsertRequest, Database.Room>();
            CreateMap<Database.TypeOfRoom, Model.TypeOfRoom>();
            CreateMap<Database.RentedRooms, Model.RentedRooms>();
            CreateMap<Database.RentedResidentialBuilding, Model.RentedResidentalBuilding>();
            CreateMap<RoomUserUpdateRequest, Database.RentedRooms>();
            CreateMap<RoomUserRent_InsertRequest, Database.RentedRooms>();
            CreateMap<ApartmentUserRent_InsertRequest, Database.RentedResidentialBuilding>();
            CreateMap<ApartmentUserUpdateRequest, Database.RentedResidentialBuilding>();
            CreateMap<Model.TypeOfRoom, Database.TypeOfRoom>();
            CreateMap<Model.RoomReview, Database.RoomReview>();
            CreateMap<Database.RoomReview, Model.RoomReview>();
            CreateMap<Model.ResidentialBuildingReview, Database.ResidentialBuildingReview>();
            CreateMap<Database.ResidentialBuildingReview, Model.ResidentialBuildingReview>();
            CreateMap<Database.RentedResidentialBuilding, Model.ResidentalBuildingReport>();  
            CreateMap<Database.RentedResidentialBuilding, Model.ResidentalBuildingReportNoFiltered>();
            CreateMap<Database.RentedRooms, Model.RoomsReport>(); 
            CreateMap<Database.RentedRooms, Model.RoomsNoFilterReport>();
        }
    }
}
