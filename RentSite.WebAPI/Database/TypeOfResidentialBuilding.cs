using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class TypeOfResidentialBuilding
    {
        public TypeOfResidentialBuilding()
        {
            ResidentialBuilding = new HashSet<ResidentialBuilding>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ResidentialBuilding> ResidentialBuilding { get; set; }
    }
}
