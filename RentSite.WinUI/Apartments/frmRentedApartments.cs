using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentSite.WinUI.Apartments
{
    public partial class frmRentedApartments : Form
    {
        private readonly APIService _rentedApartmentService = new APIService("RentedApartments");
        private readonly APIService _cityService = new APIService("City");
        private readonly APIService _typefApartment= new APIService("TypeOfResidentialBuilding");
        public frmRentedApartments()
        {
            InitializeComponent();
            this.dgvRentedApartments.DataError += this.DataGridView_DataError;
        }

        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private async void frmRentedApartments_Load(object sender, EventArgs e)
        {
            await LoadCity();
            await LoadTypeOfApartment();

            var list = await _rentedApartmentService.Get<List<Model.RentedResidentalBuilding>>();
            dgvRentedApartments.DataSource = list;
        }

        private async Task LoadCity()
        {
            var result = await _cityService.Get<List<Model.City>>(null);
            result.Insert(0, new Model.City());
            cmbCity.DataSource = result;
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "Id";
        }

        private async Task LoadTypeOfApartment()
        {
            var result = await _typefApartment.Get<List<Model.TypeOfResidentialBuilding>>(null);
            result.Insert(0, new Model.TypeOfResidentialBuilding());
            cmbTypeOfApartment.DataSource = result;
            cmbTypeOfApartment.DisplayMember = "Name";
            cmbTypeOfApartment.ValueMember = "Id";
        }

        private async void cmbTypeOfApartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idTypeOfApartment = cmbTypeOfApartment.SelectedValue;

            if (int.TryParse(idTypeOfApartment.ToString(), out int id))
            {
                await LoadApartments(id);
            }
        }
        private async Task LoadApartments(int id)
        {
            var result = await _rentedApartmentService.Get<List<Model.RentedResidentalBuilding>>(new ApartmentSearchRequest()
            {
                TypeOfResidentialBuildingId = id
            });
            dgvRentedApartments.DataSource = result;
        }

        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idCityObje = cmbCity.SelectedValue;
            if (int.TryParse(idCityObje.ToString(), out int id))
            {
                await LoadCities(id);
            }
        }
        private async Task LoadCities(int cityId)
        {
            var result = await _rentedApartmentService.Get<List<Model.RentedResidentalBuilding>>(new ApartmentSearchRequest()
            {
                CityId = cityId
            });
            dgvRentedApartments.DataSource = result;
        }
    }
}
