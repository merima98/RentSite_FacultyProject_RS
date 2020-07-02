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
    public partial class RoomsPage : ContentPage
    {
        private RoomsViewModel model;
        public RoomsPage()
        {
            InitializeComponent();
            model = new RoomsViewModel();
            this.BindingContext = model;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
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