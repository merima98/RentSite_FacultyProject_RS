using System;
using System.Collections.Generic;

namespace RentSite.WebAPI.Database
{
    public partial class TypeOfUser
    {
        public TypeOfUser()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
