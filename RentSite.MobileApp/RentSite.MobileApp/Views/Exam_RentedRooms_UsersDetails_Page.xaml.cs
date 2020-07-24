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
    public partial class Exam_RentedRooms_UsersDetails_Page : ContentPage
    {
        private Exam_RentedRoomsUsers_DetailsViewModel model = null;
        public Exam_RentedRooms_UsersDetails_Page(Room room)
        {
            InitializeComponent();
            BindingContext = model = new Exam_RentedRoomsUsers_DetailsViewModel()
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