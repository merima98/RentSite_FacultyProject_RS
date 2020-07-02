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
    public partial class ApartmentsViewModel : BaseViewModel
    {
        private readonly APIService _apartmentsService = new APIService("UserApartment");
        private readonly APIService _typeOfCity = new APIService("City");
        private readonly APIService _typeOfApartments= new APIService("TypeOfResidentialBuilding");

        


        public ApartmentsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Model.ResidentialBuilding> ApartmentsList { get; set; } = new ObservableCollection<Model.ResidentialBuilding>();
        public ObservableCollection<Model.City> TypeOfCity { get; set; } = new ObservableCollection<Model.City>();
        public ObservableCollection<Model.TypeOfResidentialBuilding> TypeOfApartments { get; set; } = new ObservableCollection<Model.TypeOfResidentialBuilding>();



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


        Model.TypeOfResidentialBuilding _selectedTypeOfApartment = null;

        public Model.TypeOfResidentialBuilding SelectedTypeOfApartments
        {
            get { return _selectedTypeOfApartment; }
            set
            {
                SetProperty(ref _selectedTypeOfApartment, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }


        public ICommand InitCommand { get; set; }

        public async Task Init() 
        {

            if (TypeOfCity.Count == 0)
            {
                var cityList = await _typeOfCity.Get<List<Model.City>>(null);

                foreach (var city in cityList)
                {
                    TypeOfCity.Add(city);
                }
            }

            if (TypeOfApartments.Count == 0)
            {
                var typeOfApartmentList = await _typeOfApartments.Get<List<Model.TypeOfResidentialBuilding>>(null);

                foreach (var apartment in typeOfApartmentList)
                {
                    TypeOfApartments.Add(apartment);
                }
            }

            if (SelectedTypeOfCity != null)
            {
                ApartmentUserSearchRequest searchRequest = new ApartmentUserSearchRequest();
                searchRequest.CityId = SelectedTypeOfCity.Id;

                var listApartments = await _apartmentsService.Get<IEnumerable<Model.ResidentialBuilding>>(searchRequest);
                ApartmentsList.Clear();
                foreach (var apartments in listApartments)
                {
                    if (apartments.Rented == false)
                    {
                        ApartmentsList.Add(apartments);
                    }
                }
            }

            if (SelectedTypeOfApartments != null)
            {
                ApartmentUserSearchRequest searchRequest = new ApartmentUserSearchRequest();
                searchRequest.TypeOfResidentialBuildingId = SelectedTypeOfApartments.Id;

                var listApartments = await _apartmentsService.Get<IEnumerable<Model.ResidentialBuilding>>(searchRequest);
                ApartmentsList.Clear();
                foreach (var apartments in listApartments)
                {
                    if (apartments.Rented == false)
                    {
                        ApartmentsList.Add(apartments);
                    }
                }
            }


        }


    }
}
