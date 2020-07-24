using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model.Requests
{
    public class Exam_FreeRooms_FROM_TO
    {
        public DateTime? BeginRentalDate { get; set; }
        public DateTime? EndRentalDate { get; set; }
    }
}
