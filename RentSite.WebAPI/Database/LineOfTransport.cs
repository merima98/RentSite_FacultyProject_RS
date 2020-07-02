using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class LineOfTransport
    {
        public LineOfTransport()
        {
            LineOfTransportResidentialBuilding = new HashSet<LineOfTransportResidentialBuilding>();
            LineOfTransportRoom = new HashSet<LineOfTransportRoom>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LineOfTransportResidentialBuilding> LineOfTransportResidentialBuilding { get; set; }
        public virtual ICollection<LineOfTransportRoom> LineOfTransportRoom { get; set; }
    }
}
