using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class TypeOfRoom
    {
        public TypeOfRoom()
        {
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBeds { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
