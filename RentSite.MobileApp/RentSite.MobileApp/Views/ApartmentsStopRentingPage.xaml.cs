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
    public partial class ApartmentsStopRentingPage : ContentPage
    {
        private ApartmentsStopRentingViewModel model = null;
        public ApartmentsStopRentingPage(ResidentialBuilding apartment)
        {
            InitializeComponent();

            BindingContext = model = new ApartmentsStopRentingViewModel()
            {
                Apartment = apartment
            };
        }

        public void OnBackButtonPressed(object sender, EventArgs args)
        {
            var secondaryPage = new RentedUserApartmentPage();
            Navigation.InsertPageBefore(secondaryPage, this);
            Navigation.PopAsync();
        }
        public void ButtonPressed(object sender, EventArgs args)
        {
            DisplayAlert("Message", "Successfully! You stoped renting apartment!", "OK");


            Thread.Sleep(1000);
        }
    }
}