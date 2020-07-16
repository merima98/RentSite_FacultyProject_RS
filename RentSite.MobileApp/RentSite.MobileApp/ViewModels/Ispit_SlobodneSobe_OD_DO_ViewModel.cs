using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RentSite.MobileApp.ViewModels
{
  

    public class Ispit_SlobodneSobe_OD_DO_ViewModel : BaseViewModel
    {
        private readonly APIService _roomsService = new APIService("Ispit_SlobodneSobe_OD_DO");




        public Ispit_SlobodneSobe_OD_DO_ViewModel()
        {
            TraziCommand = new Command(async () => await Trazi());
        }

        public ObservableCollection<Model.Room> RoomsList { get; set; } = new ObservableCollection<Model.Room>();


        DateTime _dateFrom = default;

        public DateTime SelectedDateFrom
        {
            get { return _dateFrom; }
            set
            {
                SetProperty(ref _dateFrom, value);
            }
        }

        DateTime _dateTo = default;

        public DateTime SelectedDateTo
        {
            get { return _dateTo; }
            set
            {
                SetProperty(ref _dateTo, value);
            }
        }
        public ICommand TraziCommand { get; set; }

        public async Task Trazi()
        {
            if (SelectedDateFrom.Date >= DateTime.Now && SelectedDateTo.Date >= DateTime.Now && SelectedDateTo.Date >= SelectedDateFrom.Date)
            {
                Ispit_SlobodneSobe_OD_DO_Request searchRequest = new Ispit_SlobodneSobe_OD_DO_Request();
                searchRequest.BeginRentalDate = SelectedDateFrom.Date;
                searchRequest.EndRentalDate = SelectedDateTo.Date;

                var listRooms = await _roomsService.Get<IEnumerable<Model.Room>>(searchRequest);
                RoomsList.Clear();
                foreach (var rooms in listRooms)
                {
                    RoomsList.Add(rooms);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Upozorenje", "Datum od >= tretutni datim | Datum do >= trenutni datum | Datum Do >= Datum Od", "OK");
            }

        }
    }
}
