using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class LineOfTransportRoom
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? LineOfTransportId { get; set; }

        public virtual LineOfTransport LineOfTransport { get; set; }
        public virtual Room Room { get; set; }
    }
}
