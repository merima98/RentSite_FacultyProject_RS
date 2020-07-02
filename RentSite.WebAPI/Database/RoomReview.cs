using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class RoomReview
    {
        public int Id { get; set; }
        public int? Mark { get; set; }
        public int? RoomId { get; set; }
        public int? UserId { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
