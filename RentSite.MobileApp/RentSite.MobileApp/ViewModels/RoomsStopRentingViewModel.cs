using RentSite.Model;
using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RentSite.MobileApp.ViewModels
{
    public class RoomsStopRentingViewModel : BaseViewModel
    {
        private readonly APIService _rentRoomService = new APIService("RoomUserRent");
        private readonly APIService _roomService = new APIService("Room");
        private readonly APIService _roomReviewService = new APIService("RoomReview");


        public RoomsStopRentingViewModel()
        {
            RentCommand = new Command(async () => await StopRentingRoom());
            AddMarkCommand = new Command(async () => await AddMark());

        }

        public Room Room { get; set; }

        public ICommand RentCommand { get; set; }

        public ICommand AddMarkCommand { get; set; }

        int _Mark =0;  
        public int Mark
        {
            get { return _Mark; }
            set { SetProperty(ref _Mark, value); }
        }

        async Task AddMark() 
        {
            var userID = APIService.UserId;

            if (Mark > 0 && Mark < 6) {

                var entity = new Model.RoomReview()
                {
                    Mark = Mark,
                    RoomId = Room.Id,
                    UserId = userID
                };

                await _roomReviewService.Insert<Model.RoomReview>(entity);
                await Application.Current.MainPage.DisplayAlert("Message", "Successfully! You added your review for this room!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You have to add mark in range 1 - 5!", "OK");
            }
        }


        async Task StopRentingRoom()
        {

            var userID = APIService.UserId;

            RoomUserSearchRequest searchRequest = new RoomUserSearchRequest()
            {
                UserId = userID
            };


            var temp = await _rentRoomService.Get<List<Model.RentedRooms>>(searchRequest);
            var request = new RoomUserRent_UpdateRequest();
            GregorianCalendar persianCalendar = new GregorianCalendar();

            foreach (var x in temp)    
            {
                if (x.RoomId == Room.Id)
                {
                    request.Id = x.Id;
                    request.BeginRentalDate = x.BeginRentalDate;
                    request.EndRentalDate = DateTime.Now;
                    request.RoomId = Room.Id;
                    request.UserId = APIService.UserId;
                    request.Year = persianCalendar.GetYear(x.BeginRentalDate ?? DateTime.Now);
                }
            }

            await _rentRoomService.Update<Model.RentedRooms>(request.Id, request);

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
                Rented = false,
                TypeOfHeating = Room.TypeOfHeating,
                TypeOfRoomId = Room.TypeOfRoomId
            };
            await _roomService.Update<Model.Room>(Room.Id, requestUpdate);
        }
    }
}
