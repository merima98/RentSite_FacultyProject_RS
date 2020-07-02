using RentSite.MobileApp.Models;
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
    public partial class ApartmentsPage : ContentPage
    {
        private ApartmentsViewModel model;

        public ApartmentsPage()
        {
            InitializeComponent();
            model = new ApartmentsViewModel();
            this.BindingContext = model;
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasNavigationBar(this, true);

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private  async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.ResidentialBuilding;
            await  Navigation.PushAsync(new ApartmentsRentPage(item));   
        }
        public void OnBackButtonPressed(object sender, EventArgs args)
        {
            var secondaryPage = new ApartmentsPage();
            Navigation.InsertPageBefore(secondaryPage, this);
            Navigation.PopAsync();
        }

    }
}