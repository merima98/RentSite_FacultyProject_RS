using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RentSite.MobileApp.Models;

namespace RentSite.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Begin, (NavigationPage)Detail);


        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Begin:
                        MenuPages.Add(id, new NavigationPage(new ApartmentsFirstPage()));
                        break;
                    case (int)MenuItemType.User:
                        MenuPages.Add(id, new NavigationPage(new UserInformationPage()));
                        break;
                    case (int)MenuItemType.Rooms:
                        MenuPages.Add(id, new NavigationPage(new RoomsPage()));
                        break;
                    case (int)MenuItemType.Apartments:
                        MenuPages.Add(id, new NavigationPage(new ApartmentsPage()));
                        break;

                    case (int)MenuItemType.RentedRooms:
                        MenuPages.Add(id, new NavigationPage(new RentedUserRoomsPage()));
                        break;
                    case (int)MenuItemType.RentedApartments:
                        MenuPages.Add(id, new NavigationPage(new RentedUserApartmentPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
           
        }
    }
}