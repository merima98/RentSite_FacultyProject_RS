using RentSite.MobileApp.ViewModels;
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
    public partial class ApartmentsRentPage : ContentPage
    {
        private ApartmentsRentViewModel model = null;

        public ApartmentsRentPage(Model.ResidentialBuilding apartment = null)
        {
            InitializeComponent();
            BindingContext = model = new ApartmentsRentViewModel()
            {
                Apartment = apartment
            };
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
        }

        public void ButtonPressed(object sender, EventArgs args)
        {
            DisplayAlert("Message", "Successfully! You rented apartment!", "OK");

            Thread.Sleep(1000);
        }
        public void OnBackButtonPressed(object sender, EventArgs args)
        {
            var secondaryPage = new ApartmentsPage();
            Navigation.InsertPageBefore(secondaryPage, this);
            Navigation.PopAsync();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }


        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.ResidentialBuilding;
            await Navigation.PushAsync(new ApartmentsRentPage(item));  
        }

    }
}