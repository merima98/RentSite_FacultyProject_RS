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
    public class RentedUserRoomsViewModel
    {


        private readonly APIService _roomsRentedUserService = new APIService("RoomUserRent");
        private readonly APIService _roomsService = new APIService("Room");

        public RentedUserRoomsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }


        public ICommand InitCommand { get; set; }
        public ObservableCollection<Model.Room> RentedRoomsList { get; set; } = new ObservableCollection<Model.Room>();


        public async Task Init()
        {
            var userID = APIService.UserId;

            RoomUserSearchRequest searchRequest = new RoomUserSearchRequest()
            {
                UserId = userID
            };

            var rentedList = await _roomsRentedUserService.Get<IEnumerable<Model.RentedRooms>>(searchRequest);
            var rooms = await _roomsService.Get<IEnumerable<Model.Room>>();

            RentedRoomsList.Clear();

            foreach (var rented in rentedList)
            {
                foreach (var room in rooms)
                {
                    if (rented.RoomId == room.Id)
                    {
                        RentedRoomsList.Add(room);
                    }
                }
            }
        }

    }
}
