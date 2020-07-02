using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentSite.Model.Requests
{
    public class RoomInsertRequest
    {
        [Required(ErrorMessage = "You must  enter an Adress!")]
        public string Address { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "You must  enter a Price!")]
        [Range(1, 1000)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "You must  enter a Picture!")]
        
        public byte[] Picture { get; set; }
        [Required(ErrorMessage = "You must  enter a Floor!")]
        [Range(1, 100)]
        public int Floor { get; set; }
        [Required(ErrorMessage = "You must  enter is Armored door or not!")]

        public bool? ArmoredDoor { get; set; }
        [Required(ErrorMessage = "You must  enter Type of heating!")]

        public string TypeOfHeating { get; set; }
        [Required(ErrorMessage = "You must  enter an Area!")]

        public string Area { get; set; }
        [Required(ErrorMessage = "You must  enter is Newly built or not!")]

        public bool? NewlyBuilt { get; set; }
        [Required(ErrorMessage = "You must  enter Date of renewal!")]

        public DateTime? DateOfRenewal { get; set; }
        [Required(ErrorMessage = "You must  enter Date of publication!")]

        public DateTime? DateOfPublication { get; set; }
        [Required(ErrorMessage = "You must  enter a City!")]

        public int? CityId { get; set; }
        [Required(ErrorMessage = "You must  enter Type of room!")]

        public int? TypeOfRoomId { get; set; }

        public bool? Rented { get; set; }

        public List<int> LineOfTransport { get; set; } = new List<int>();


    }
}
