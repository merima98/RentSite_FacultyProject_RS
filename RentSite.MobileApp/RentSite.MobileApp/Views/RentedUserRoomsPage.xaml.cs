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
    public partial class RentedUserRoomsPage : ContentPage
    {
        private RentedUserRoomsViewModel model = null;
        public RentedUserRoomsPage()
        {
            InitializeComponent();
            model = new RentedUserRoomsViewModel();
            this.BindingContext = model;
            
        }



        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.Room;
            await Navigation.PushAsync(new RoomsStopRenting(item));   
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}