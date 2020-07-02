using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentSite.WebAPI.Database
{
    public class Data
    {
        public static void Seed(RentSiteContext context)
        {

            context.Database.Migrate();
        }
    }
}
