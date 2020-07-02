using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RentSite.MobileApp.Services;
using RentSite.MobileApp.Views;

namespace RentSite.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }
         
    }
}
