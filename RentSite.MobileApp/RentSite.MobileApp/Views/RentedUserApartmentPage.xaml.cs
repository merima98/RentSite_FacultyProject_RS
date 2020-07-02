using RentSite.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentSite.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentedUserApartmentPage : ContentPage
    {
        private RentedUserApartmentViewModel model = null;
        public RentedUserApartmentPage()
        {
            InitializeComponent();
            model = new RentedUserApartmentViewModel();
            this.BindingContext = model;
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }



        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.ResidentialBuilding;
            await Navigation.PushAsync(new ApartmentsStopRentingPage(item));  
        }
    }
}