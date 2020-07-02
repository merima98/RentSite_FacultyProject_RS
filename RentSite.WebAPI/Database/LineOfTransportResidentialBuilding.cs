using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class LineOfTransportResidentialBuilding
    {
        public int Id { get; set; }
        public int? ResidentialBuildingId { get; set; }
        public int? LineOfTransportId { get; set; }

        public virtual LineOfTransport LineOfTransport { get; set; }
        public virtual ResidentialBuilding ResidentialBuilding { get; set; }
    }
}
