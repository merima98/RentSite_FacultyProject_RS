using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model
{
    public class ResidentalBuildingReportNoFiltered
    {
        public int Id { get; set; }
        public DateTime? BeginRentalDate { get; set; }
        public string BeginRentalDateString { get; set; }


        public DateTime? EndRentalDate { get; set; }
        public string EndRentalDateString { get; set; }

        public int? UserId { get; set; }
        public int? ResidentialBuildingId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? Year { get; set; }

        public double? TotalPrice { get; set; }

        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public bool? Rented { get; set; }
    }
}
