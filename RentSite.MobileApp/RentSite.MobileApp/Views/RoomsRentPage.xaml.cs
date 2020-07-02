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
    public partial class RoomsRentPage : ContentPage
    {
        private RoomsRentViewModel model = null;
        public RoomsRentPage(Room room)
        {
            InitializeComponent();
            BindingContext = model = new RoomsRentViewModel()
            {
                Room = room
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();   
        }
        public  void ButtonPressed(object sender, EventArgs args)
        {
            DisplayAlert("Message", "Successfully! You rented room!", "OK");

            Thread.Sleep(1000);
        }


        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.Room;
            await Navigation.PushAsync(new RoomsRentPage(item));  
        }
        public void OnBackButtonPressed(object sender, EventArgs args)
        {
            var secondaryPage = new RoomsPage();
            Navigation.InsertPageBefore(secondaryPage, this);
            Navigation.PopAsync();
        }

    }
}