using RentSite.Model;
using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RentSite.MobileApp.ViewModels
{
    public class ApartmentsStopRentingViewModel : BaseViewModel
    {
        
        private readonly APIService _rentApartmentService = new APIService("ApartmentUserRent");
        private readonly APIService _apartmentService = new APIService("Apartments");
        private readonly APIService _apartmentsReviewService = new APIService("ApartmentReview");


        public ApartmentsStopRentingViewModel()
        {
            RentCommand = new Command(async () => await StopRentingApartment());
            AddMarkCommand = new Command(async () => await AddMark());
        }
        public ICommand AddMarkCommand { get; set; }

        public ResidentialBuilding Apartment{ get; set; }
        public ICommand RentCommand { get; set; }


        int _Mark = 0;
        public int Mark
        {
            get { return _Mark; }
            set { SetProperty(ref _Mark, value); }
        }

        async Task AddMark()
        {
            var userID = APIService.UserId;

            if (Mark > 0 && Mark < 6)
            {

                var entity = new Model.ResidentialBuildingReview()
                {
                    Mark = Mark,
                    ResidentialBuildingId = Apartment.Id,
                    UserId = userID
                };

                await _apartmentsReviewService.Insert<Model.ResidentialBuildingReview>(entity);
                await Application.Current.MainPage.DisplayAlert("Message", "Successfully! You added your review for this apartment!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You have to add mark in range 1 - 5!", "OK");
            }
        }

        async Task StopRentingApartment()
        { 
            var userID = APIService.UserId;

            ApartmentUserSearchRequest searchRequest = new ApartmentUserSearchRequest()
            {
                UserId = userID
            };

            var temp = await _rentApartmentService.Get<List<Model.RentedResidentalBuilding>>(searchRequest);
            var request = new ApartmentUserUpdateRequest();

            GregorianCalendar persianCalendar = new GregorianCalendar();

            foreach (var x in temp)
            {
                if (x.ResidentialBuildingId == Apartment.Id)
                {
                    request.Id = x.Id;
                    request.BeginRentalDate = x.BeginRentalDate;
                    request.EndRentalDate = DateTime.Now;
                    request.ResidentialBuildingId = Apartment.Id;
                    request.UserId = APIService.UserId;
                    request.Year = persianCalendar.GetYear(x.BeginRentalDate??DateTime.Now);
                }
            }

            await _rentApartmentService.Update<Model.RentedResidentalBuilding>(request.Id, request);


            var requestUpdate = new ApartmentsInsertRequest()
            {
                Address = Apartment.Address,
                Area = Apartment.Area,
                ArmoredDoor = Apartment.ArmoredDoor,
                CityId = Apartment.CityId,
                DateOfPublication = Apartment.DateOfPublication,
                DateOfRenewal = Apartment.DateOfRenewal,
                Description = Apartment.Description,
                Floor = Apartment.Floor,
                NewlyBuilt = Apartment.NewlyBuilt,
                NubmerOfFloors = Apartment.NubmerOfFloors,
                NumberOfRooms = Apartment.NumberOfRooms,
                Picture = Apartment.Picture,
                Price = Apartment.Price,
                Rented = false,
                TypeOfHeating = Apartment.TypeOfHeating,
                TypeOfResidentialBuildingId = Apartment.TypeOfResidentialBuildingId
            };

            await _apartmentService.Update<Model.ResidentialBuilding>(Apartment.Id, requestUpdate);
        }

    }
}
