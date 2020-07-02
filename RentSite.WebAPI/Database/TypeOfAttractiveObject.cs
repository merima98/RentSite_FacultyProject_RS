using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class TypeOfAttractiveObject
    {
        public TypeOfAttractiveObject()
        {
            AttractiveObjects = new HashSet<AttractiveObjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AttractiveObjects> AttractiveObjects { get; set; }
    }
}
