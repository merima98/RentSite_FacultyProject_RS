using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentSite.Model
{
    public class RoomReview
    {
        public int? Mark { get; set; }
        public int? RoomId { get; set; }
        public int? UserId { get; set; }
    }
}
