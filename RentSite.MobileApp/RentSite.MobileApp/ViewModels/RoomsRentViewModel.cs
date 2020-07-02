using RentSite.Model;
using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RentSite.MobileApp.ViewModels
{
    public class RoomsRentViewModel
    {
        private readonly APIService _rentRoomService = new APIService("RoomUserRent");
        private readonly APIService _roomService = new APIService("SimilarRoomsUser");
        private readonly APIService _roomsService = new APIService("Room");



        public RoomsRentViewModel()
        {
            RentCommand = new Command(async () => await RentRoom());
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Model.Room> RoomsList { get; set; } = new ObservableCollection<Model.Room>();

        public Room Room { get; set; }
        public ICommand RentCommand { get; set; }

        async Task RentRoom() 
        {
            GregorianCalendar persianCalendar = new GregorianCalendar();

            var request = new RoomUserRent_InsertRequest()
                {
                    BeginRentalDate = DateTime.Now,
                    EndRentalDate = DateTime.Parse("9999-12-31"),
                    Year = persianCalendar.GetYear(DateTime.Now),
                    RoomId = Room.Id,
                    UserId = APIService.UserId
                };
                await _rentRoomService.Insert<Model.RentedRooms>(request);

            var requestUpdate = new RoomInsertRequest()
                {

                    Address = Room.Address,
                    Area = Room.Area,
                    ArmoredDoor = Room.ArmoredDoor,
                    CityId = Room.CityId,
                    DateOfPublication = Room.DateOfPublication,
                    DateOfRenewal = Room.DateOfRenewal,
                    Description = Room.Description,
                    Floor = Room.Floor,
                    NewlyBuilt = Room.NewlyBuilt,
                    Picture = Room.Picture,
                    Price = Room.Price,
                    Rented = true,
                    TypeOfHeating = Room.TypeOfHeating,
                    TypeOfRoomId = Room.TypeOfRoomId
                };
                await _roomsService.Update<Model.Room>(Room.Id, requestUpdate);
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {

            var listRoom = await _roomService.Get<IEnumerable<Model.Room>>(Room.Id);
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
