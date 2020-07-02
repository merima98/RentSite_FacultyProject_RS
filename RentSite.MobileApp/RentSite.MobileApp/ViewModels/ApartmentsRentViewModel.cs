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
    public class ApartmentsRentViewModel
    {

        private readonly APIService _apartmentsService = new APIService("SimilarApartmentsUser");
        private readonly APIService _rentApartmentService = new APIService("ApartmentUserRent");
        private readonly APIService _apartmentsMainService = new APIService("Apartments");

        

        public ApartmentsRentViewModel()
        {
            RentCommand = new Command(async () => await RentApartment());
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Model.ResidentialBuilding> ApartmentsList { get; set; } = new ObservableCollection<Model.ResidentialBuilding>();

        public Model.ResidentialBuilding Apartment { get; set; }

        public ICommand RentCommand { get; set; }

        public async Task RentApartment()
        {
            GregorianCalendar persianCalendar = new GregorianCalendar();

            var request = new ApartmentUserRent_InsertRequest()
            {
                BeginRentalDate = DateTime.Now,
                Year = persianCalendar.GetYear(DateTime.Now),
                EndRentalDate = DateTime.Parse("9999-12-31"),
                ResidentialBuildingId = Apartment.Id,
                UserId = APIService.UserId
            };

            await _rentApartmentService.Insert<Model.RentedResidentalBuilding>(request);


            ApartmentsInsertRequest requestUpdate = new ApartmentsInsertRequest()
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
                Rented = true,
                TypeOfHeating = Apartment.TypeOfHeating,
                TypeOfResidentialBuildingId = Apartment.TypeOfResidentialBuildingId
            };
            await _apartmentsMainService.Update<Model.ResidentialBuilding>(Apartment.Id, requestUpdate);
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {

            var listApartment = await _apartmentsService.Get<IEnumerable<Model.ResidentialBuilding>>(Apartment.Id);
            ApartmentsList.Clear();
            foreach (var apartments in listApartment)
            {
                if (apartments.Rented == false)
                {
                    ApartmentsList.Add(apartments);
                }
            }
        }


    }
}
