using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentSite.Model.Requests
{
    public class ApartmentsInsertRequest
    {
        [Required(ErrorMessage = "You must  enter an Adress!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must  enter a Description!")]
        public string Description { get; set; }

        [Range(1, 1000, ErrorMessage = "You must enter number value")]
        public decimal? Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "You must enter number value")]

        public int? Floor { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "You must enter number value")]

        public int? NubmerOfFloors { get; set; }
        [Required(ErrorMessage = "You must  enter a Picture!")]
        public byte[] Picture { get; set; }
        [Required(ErrorMessage = "You must  enter Number of rooms!")]

        [Range(0, int.MaxValue, ErrorMessage = "You must enter number value")]
        public int? NumberOfRooms { get; set; }
        [Required(ErrorMessage = "You must  enter value is it Armored door or not!")]

        public bool? ArmoredDoor { get; set; }
        [Required(ErrorMessage = "You must  enter Type of heating!")]

        public string TypeOfHeating { get; set; }
        [Required(ErrorMessage = "You must  enter an Area!")]

        public string Area { get; set; }
        [Required(ErrorMessage = "You must  enter is it Newly built or not!")]

        public bool? NewlyBuilt { get; set; }
        [Required(ErrorMessage = "You must  enter Date of renewal!")]

        public DateTime? DateOfRenewal { get; set; }
        [Required(ErrorMessage = "You must  enter Date of publication!")]

        public DateTime? DateOfPublication { get; set; }
        [Required(ErrorMessage = "You must  enter City!")]

        public int? CityId { get; set; }
        [Required(ErrorMessage = "You must  enter Type of Apartment!")]

        public int? TypeOfResidentialBuildingId { get; set; }
        [Required(ErrorMessage = "You must  enter is it Rented or not!")]

        public bool? Rented { get; set; }

        public List<int> LineOfTransport{ get; set; } = new List<int>();
    }
}
