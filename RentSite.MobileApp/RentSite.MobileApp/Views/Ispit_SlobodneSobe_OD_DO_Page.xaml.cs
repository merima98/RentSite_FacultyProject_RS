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
    public partial class Ispit_SlobodneSobe_OD_DO_Page : ContentPage
    {
        public Ispit_SlobodneSobe_OD_DO_Page()
        {
            InitializeComponent();
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.Room;
            await Navigation.PushAsync(new Ispit_RentaniSobeKorisnici_OD_DO_DETALJI_Page(item));
        }

         
    }
}