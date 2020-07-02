using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model.Requests
{
    public class ApartmentUserRent_InsertRequest
    {
        public DateTime? BeginRentalDate { get; set; }
        public DateTime? EndRentalDate { get; set; }
        public int? UserId { get; set; }
        public int? ResidentialBuildingId { get; set; }
        public int? Year { get; set; }


    }
}
