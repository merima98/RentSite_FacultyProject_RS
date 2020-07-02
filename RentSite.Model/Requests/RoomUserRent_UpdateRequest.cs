﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.Model.Requests
{
    public class RoomUserRent_UpdateRequest
    {
        public int Id { get; set; }

        public DateTime? BeginRentalDate { get; set; }
        public DateTime? EndRentalDate { get; set; }
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
        public int? Year { get; set; }
    }
}