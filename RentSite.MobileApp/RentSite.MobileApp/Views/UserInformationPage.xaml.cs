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
    public partial class UserInformationPage : ContentPage
    {
        UserInformationsViewModel model = null;
        public UserInformationPage()
        {
            InitializeComponent();
            BindingContext = model = new UserInformationsViewModel();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new LoginPage());

            var secondaryPage = new LoginPage();
            Navigation.InsertPageBefore(secondaryPage, this);
            await Navigation.PopAsync();
        }
    }
}