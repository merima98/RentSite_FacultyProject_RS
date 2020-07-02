using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model.Requests
{
    public class ApartmentSearchRequest
    {
        public int? CityId { get; set; }
        public int? TypeOfResidentialBuildingId { get; set; }
    }
}
