using GalaSoft.MvvmLight;
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
    public class RoomsViewModel : BaseViewModel
    {
        private readonly APIService _roomsService = new APIService("RoomUser");
        private readonly APIService _typeOfRoom = new APIService("TypeOfRoom");
        private readonly APIService _typeOfCity = new APIService("City");


        public RoomsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }


        public ObservableCollection<Model.Room> RoomsList { get; set; } = new ObservableCollection<Model.Room>();
        public ObservableCollection<Model.TypeOfRoom> TypeOfRoomList { get; set; } = new ObservableCollection<Model.TypeOfRoom>();
        public ObservableCollection<Model.City> TypeOfCity { get; set; } = new ObservableCollection<Model.City>();


        Model.TypeOfRoom _selectedTypeOfRoom = null;

        public Model.TypeOfRoom SelectedTypeOfRoom
        {
            get { return _selectedTypeOfRoom; }
            set
            {
                SetProperty(ref _selectedTypeOfRoom, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        Model.City _selectedTypeOfCity = null;

        public Model.City SelectedTypeOfCity
        {
            get { return _selectedTypeOfCity; }
            set
            {
                SetProperty(ref _selectedTypeOfCity, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }


        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (TypeOfRoomList.Count == 0)
            {
                var typeOfRoomList = await _typeOfRoom.Get<List<Model.TypeOfRoom>>(null);

                foreach (var room in typeOfRoomList)
                {
                    TypeOfRoomList.Add(room);
                }
            }

            if (TypeOfCity.Count == 0)
            {
                var cityList = await _typeOfCity.Get<List<Model.City>>(null);

                foreach (var city in cityList)
                {
                    TypeOfCity.Add(city);
                }
            }

            if (SelectedTypeOfRoom !=null)
            {
                RoomUserSearchRequest searchRequest = new RoomUserSearchRequest();
                searchRequest.TypeOfRoomId = SelectedTypeOfRoom.Id;
                var listRoom = await _roomsService.Get<IEnumerable<Model.Room>>(searchRequest);
                RoomsList.Clear();
                foreach (var room in listRoom)
                {
                    if (room.Rented == false)
                    {
                        RoomsList.Add(room);
                    }
                }
            }

            if (SelectedTypeOfCity != null)
            {
                RoomUserSearchRequest searchRequest = new RoomUserSearchRequest();
                searchRequest.CityId = SelectedTypeOfCity.Id;
                var listRoom = await _roomsService.Get<IEnumerable<Model.Room>>(searchRequest);
                RoomsList.Clear();
                foreach (var room in listRoom)
                {
                    if (room.Rented == false)
                    {
                        RoomsList.Add(room);
                    }
                }
            }
        }



    }
}
