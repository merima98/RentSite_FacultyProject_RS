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
    public partial class ApartmentsFirstPage : ContentPage
    {
        ApartmentsFirstViewModel model = null;
        public ApartmentsFirstPage()
        {
            InitializeComponent();
            BindingContext = model = new ApartmentsFirstViewModel();
        }

        protected async  override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        
    }
}