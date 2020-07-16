using System;
using System.Collections.Generic;
using System.Text;

namespace RentSite.MobileApp.Models
{
    public enum MenuItemType
    {
        Begin,
        User, 
        Rooms,
        Apartments,
        RentedRooms, 
        RentedApartments,
        Ispit
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
