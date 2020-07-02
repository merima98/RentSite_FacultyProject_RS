using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RentSite.MobileApp.ViewModels
{
    public class ApartmentsFirstViewModel
    {
        private readonly APIService _apartmentsUserServicce = new APIService("ApartmentsUser");
        public ApartmentsFirstViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Model.ResidentialBuilding> ApartmentsList { get; set; } = new ObservableCollection<Model.ResidentialBuilding>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _apartmentsUserServicce.Get<List<Model.ResidentialBuilding>>();

            ApartmentsList.Clear();
            foreach (var apartment in list)
            {
                ApartmentsList.Add(apartment);
            }
        }
    }
}
