using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class User
    {
        public User()
        {
            RentedResidentialBuilding = new HashSet<RentedResidentialBuilding>();
            RentedRooms = new HashSet<RentedRooms>();
            ResidentialBuildingReview = new HashSet<ResidentialBuildingReview>();
            RoomReview = new HashSet<RoomReview>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool? Status { get; set; }
        public int? TypeOfUserId { get; set; }

        public virtual TypeOfUser TypeOfUser { get; set; }
        public virtual ICollection<RentedResidentialBuilding> RentedResidentialBuilding { get; set; }
        public virtual ICollection<RentedRooms> RentedRooms { get; set; }
        public virtual ICollection<ResidentialBuildingReview> ResidentialBuildingReview { get; set; }
        public virtual ICollection<RoomReview> RoomReview { get; set; }
    }
}
