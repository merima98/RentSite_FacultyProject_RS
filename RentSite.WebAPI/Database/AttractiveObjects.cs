using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class AttractiveObjects
    {
        public AttractiveObjects()
        {
            AttractiveObjectsRoom = new HashSet<AttractiveObjectsRoom>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TypeOfAttractiveObjectId { get; set; }

        public virtual TypeOfAttractiveObject TypeOfAttractiveObject { get; set; }
        public virtual ICollection<AttractiveObjectsRoom> AttractiveObjectsRoom { get; set; }
    }
}
