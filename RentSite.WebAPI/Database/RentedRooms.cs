using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class RentedRooms
    {
        public int Id { get; set; }
        public DateTime? BeginRentalDate { get; set; }
        public DateTime? EndRentalDate { get; set; }
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
        public int? Year { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
