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
    public class RentedUserApartmentViewModel : BaseViewModel
    {
        private readonly APIService _apartmentsRentedUserService = new APIService("ApartmentUserRent");
        private readonly APIService _apartmentsService = new APIService("Apartments");


        public RentedUserApartmentViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }
        public ObservableCollection<Model.ResidentialBuilding> RentedApartmentsList { get; set; } = new ObservableCollection<Model.ResidentialBuilding>();


        public async Task Init()
        {
            var userID = APIService.UserId;

            ApartmentUserSearchRequest search = new ApartmentUserSearchRequest()
            {
                UserId = userID
            };


            var rentedList = await _apartmentsRentedUserService.Get<IEnumerable<Model.RentedResidentalBuilding>>(search);
            var apartments = await _apartmentsService.Get<IEnumerable<Model.ResidentialBuilding>>();
            RentedApartmentsList.Clear();
            foreach (var rented in rentedList)
            {
                foreach (var apartment in apartments)
                {
                    if (rented.ResidentialBuildingId==apartment.Id)
                    {
                    RentedApartmentsList.Add(apartment);
                    }
                }
            }

        }
    }
}
