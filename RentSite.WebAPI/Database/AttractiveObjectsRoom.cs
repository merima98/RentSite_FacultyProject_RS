using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class AttractiveObjectsRoom
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? AttractiveObjectsId { get; set; }

        public virtual AttractiveObjects AttractiveObjects { get; set; }
        public virtual Room Room { get; set; }
    }
}
