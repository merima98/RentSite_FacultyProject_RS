using RentSite.MobileApp.ViewModels;
using RentSite.Model;
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
    public partial class Ispit_RentaniSobeKorisnici_OD_DO_DETALJI_Page : ContentPage
    {
        private Ispit_RentaniSobeKorisnici_OD_DO_DETALJI_ViewModel model = null;
        public Ispit_RentaniSobeKorisnici_OD_DO_DETALJI_Page(Room room)
        {
            InitializeComponent();
            BindingContext = model = new Ispit_RentaniSobeKorisnici_OD_DO_DETALJI_ViewModel()
            {
                Room = room
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}