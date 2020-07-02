using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model.Requests
{
    public class ApartmentUserUpdateRequest
    {
        public int Id { get; set; }
        public DateTime? BeginRentalDate { get; set; }
        public DateTime? EndRentalDate { get; set; }
        public int? UserId { get; set; }
        public int? ResidentialBuildingId { get; set; }
        public int? Year { get; set; }

    }
}
