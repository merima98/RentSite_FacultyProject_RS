using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model
{
    public class ResidentialBuilding
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Floor { get; set; }
        public int? NubmerOfFloors { get; set; }
        public byte[] Picture { get; set; }
        public int? NumberOfRooms { get; set; }
        public bool? ArmoredDoor { get; set; }
        public string TypeOfHeating { get; set; }
        public string Area { get; set; }
        public bool? NewlyBuilt { get; set; }
        public DateTime? DateOfRenewal { get; set; }
        public DateTime? DateOfPublication { get; set; }
        public int? CityId { get; set; }
        public int? TypeOfResidentialBuildingId { get; set; }
        public bool? Rented { get; set; }
    }
}
