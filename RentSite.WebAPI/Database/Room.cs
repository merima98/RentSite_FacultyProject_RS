using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class Room
    {
        public Room()
        {
            AttractiveObjectsRoom = new HashSet<AttractiveObjectsRoom>();
            LineOfTransportRoom = new HashSet<LineOfTransportRoom>();
            RentedRooms = new HashSet<RentedRooms>();
            RoomReview = new HashSet<RoomReview>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Picture { get; set; }
        public int Floor { get; set; }
        public bool? ArmoredDoor { get; set; }
        public string TypeOfHeating { get; set; }
        public string Area { get; set; }
        public bool? NewlyBuilt { get; set; }
        public DateTime? DateOfRenewal { get; set; }
        public DateTime? DateOfPublication { get; set; }
        public int? CityId { get; set; }
        public int? TypeOfRoomId { get; set; }
        public bool? Rented { get; set; }

        public virtual City City { get; set; }
        public virtual TypeOfRoom TypeOfRoom { get; set; }
        public virtual ICollection<AttractiveObjectsRoom> AttractiveObjectsRoom { get; set; }
        public virtual ICollection<LineOfTransportRoom> LineOfTransportRoom { get; set; }
        public virtual ICollection<RentedRooms> RentedRooms { get; set; }
        public virtual ICollection<RoomReview> RoomReview { get; set; }
    }
}
