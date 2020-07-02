using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class ResidentialBuildingReview
    {
        public int Id { get; set; }
        public int? Mark { get; set; }
        public int? ResidentialBuildingId { get; set; }
        public int? UserId { get; set; }

        public virtual ResidentialBuilding ResidentialBuilding { get; set; }
        public virtual User User { get; set; }
    }
}
