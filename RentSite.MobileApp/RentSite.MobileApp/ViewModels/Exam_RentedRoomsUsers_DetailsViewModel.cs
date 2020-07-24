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
   
    public class Exam_RentedRoomsUsers_DetailsViewModel : BaseViewModel
    {

        //exam: 
        public ObservableCollection<Model.RentedRooms> RoomsList { get; set; } = new ObservableCollection<Model.RentedRooms>();
        private readonly APIService _roomsService = new APIService("Exam_RentedRoomsUsers");

        public Exam_RentedRoomsUsers_DetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public Room Room { get; set; }
        public ICommand RentCommand { get; set; }



        public ICommand InitCommand { get; set; }

        public async Task Init()   
        {
            
            Exam_RentedRoomsUsers_FROM_TO request = new Exam_RentedRoomsUsers_FROM_TO();
            request.RoomId = Room.Id;
            var listRoom = await _roomsService.Get<IEnumerable<Model.RentedRooms>>(request);
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
