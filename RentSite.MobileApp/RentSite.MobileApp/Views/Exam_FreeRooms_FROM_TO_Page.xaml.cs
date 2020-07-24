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
    public partial class Exam_FreeRooms_FROM_TO_Page : ContentPage
    {
        public Exam_FreeRooms_FROM_TO_Page()
        {
            InitializeComponent();
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.Room;
            await Navigation.PushAsync(new Exam_RentedRooms_UsersDetails_Page(item));
        }

         
    }
}