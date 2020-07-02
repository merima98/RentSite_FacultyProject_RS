using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class City
    {
        public City()
        {
            ResidentialBuilding = new HashSet<ResidentialBuilding>();
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ResidentialBuilding> ResidentialBuilding { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
