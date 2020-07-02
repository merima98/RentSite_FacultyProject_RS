using System;
using System.Collections;
using System.Collections.Generic;

namespace RentSite.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool? Status { get; set; }
        public int? TypeOfUserId { get; set; }

    }
}
