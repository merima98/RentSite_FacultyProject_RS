using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model.Requests
{
    public class RoomUserSearchRequest
    {
        public int? CityId { get; set; }
        public int? TypeOfRoomId { get; set; }
        public int? UserId { get; set; }
    }
}
