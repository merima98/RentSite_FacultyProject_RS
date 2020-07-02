using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentSite.Model.Requests
{
    public class YearSearchRequest
    {
        [Range(1, int.MaxValue ,ErrorMessage ="You must enter number value")]
        public int Year { get; set; }
    }
}
