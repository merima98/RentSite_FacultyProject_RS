using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class RentedResidentialBuilding
    {
        public int Id { get; set; }
        public DateTime? BeginRentalDate { get; set; }
        public DateTime? EndRentalDate { get; set; }
        public int? UserId { get; set; }
        public int? ResidentialBuildingId { get; set; }
        public int? Year { get; set; }

        public virtual ResidentialBuilding ResidentialBuilding { get; set; }
        public virtual User User { get; set; }
    }
}
