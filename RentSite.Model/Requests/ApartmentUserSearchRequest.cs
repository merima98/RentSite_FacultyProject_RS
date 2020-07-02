using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model.Requests
{
    public class ApartmentUserSearchRequest
    {
        public int? CityId { get; set; }
        public int? TypeOfResidentialBuildingId { get; set; }
        public int? UserId { get; set; }

    }
}
