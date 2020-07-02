using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model
{
    public class RentedResidentalBuilding
    {
        public int Id { get; set; }
        public DateTime? BeginRentalDate { get; set; }
        public DateTime? EndRentalDate { get; set; }
        public int? UserId { get; set; }
        public int? ResidentialBuildingId { get; set; }
        //public int? Year { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public bool? Rented { get; set; }
    }
}
