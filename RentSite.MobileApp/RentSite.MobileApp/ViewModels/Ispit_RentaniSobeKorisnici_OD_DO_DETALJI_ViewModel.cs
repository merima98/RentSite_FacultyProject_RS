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
   
    public class Ispit_RentaniSobeKorisnici_OD_DO_DETALJI_ViewModel : BaseViewModel
    {
        //private readonly APIService _rentRoomService = new APIService("RoomUserRent");
        //private readonly APIService _roomService = new APIService("SimilarRoomsUser");
        //private readonly APIService _roomsService = new APIService("Room");


        //ispit: 
        public ObservableCollection<Model.RentedRooms> RoomsList { get; set; } = new ObservableCollection<Model.RentedRooms>();
        private readonly APIService _roomsService = new APIService("Ispit_RentaniSobeKorisnici_OD_DO_");




        public Ispit_RentaniSobeKorisnici_OD_DO_DETALJI_ViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }





        public ICommand KalkulacijaCommand { get; set; }
        public Room Room { get; set; }
        public ICommand RentCommand { get; set; }


     //   public ObservableCollection<Model.Room> RoomsList { get; set; } = new ObservableCollection<Model.Room>();

        public ICommand InitCommand { get; set; }

        public async Task Init()   //potrebno je i ovo promijeniti
        {
            
            Ispit_RentaniSobeKorisnici_OD_DO_Request request = new Ispit_RentaniSobeKorisnici_OD_DO_Request();
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
