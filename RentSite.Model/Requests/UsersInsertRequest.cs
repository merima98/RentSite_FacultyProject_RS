using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentSite.Model.Requests
{
    public class UsersInsertRequest
    {
        [Required (ErrorMessage ="You must enter Name!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter Surname!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter Phone number!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "You must enter Username!")]
        public string Username { get; set; }
        [Required (ErrorMessage ="You must enter Email! Example: user@example.com")]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool? Status { get; set; }
        [Range(1,2,ErrorMessage ="Must be in range 1 - 2!")]
        [Required (ErrorMessage ="Must be selected!")]
        public int? TypeOfUserId { get; set; }
    }
}
