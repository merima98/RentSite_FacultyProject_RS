using RentSite.MobileApp.ViewModels;
using RentSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentSite.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomsStopRenting : ContentPage
    {
        private RoomsStopRentingViewModel model = null;
        public RoomsStopRenting(Room room)
        {
            InitializeComponent();
            BindingContext = model = new RoomsStopRentingViewModel()
            {
                Room = room
            };
        }
        public void OnBackButtonPressed(object sender, EventArgs args)
        {
            var secondaryPage = new RentedUserRoomsPage();
            Navigation.InsertPageBefore(secondaryPage, this);
            Navigation.PopAsync();
        }

        public void ButtonPressed(object sender, EventArgs args)
        {
            DisplayAlert("Message", "Successfully! You stoped renting room!", "OK");

            
            Thread.Sleep(1000);
        }
    }
}