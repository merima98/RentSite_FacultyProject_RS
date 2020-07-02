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
    public partial class frmApartmentsView : Form
    {
        private readonly APIService _apartmentsService = new APIService("Apartments");
        private readonly APIService _cityServiceService = new APIService("City");
        private readonly APIService _typeOfApartmentsService = new APIService("TypeOfResidentialBuilding");

        public frmApartmentsView()
        {
            InitializeComponent();
            this.dgvApartments.DataError += this.DataGridView_DataError;
        }
        protected override void OnClosing(CancelEventArgs e)  //ovo sam zadnje dodala
        {
            this.WindowState = FormWindowState.Normal;
        }

        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        private async void frmApartmentsView_Load(object sender, EventArgs e)
        {
            await LoadCity();
            await LoadTypeOfApartment();

            var list = await _apartmentsService.Get<List<Model.ResidentialBuilding>>();
            dgvApartments.DataSource = list;

        }
        private async Task LoadCity()
        {
            var result = await _cityServiceService.Get<List<Model.City>>(null);
            result.Insert(0, new Model.City());
            cmbCity.DataSource = result;
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "Id";
        }
 
        private async Task LoadTypeOfApartment()
        {
            var result = await _typeOfApartmentsService.Get<List<Model.TypeOfResidentialBuilding>>(null);
            result.Insert(0, new Model.TypeOfResidentialBuilding());
            cmbTypeOfApartment.DataSource = result;
            cmbTypeOfApartment.DisplayMember = "Name";
            cmbTypeOfApartment.ValueMember = "Id";
        }
        private async void cmbTypeOfApartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idApartmentObj = cmbTypeOfApartment.SelectedValue;


            if (int.TryParse(idApartmentObj.ToString(), out int id) )
            {
                await LoadApartments(id);
            }
        }
        private async Task LoadApartments(int idApartmentId)
        {
            var result = await _apartmentsService.Get<List<Model.ResidentialBuilding>>(new ApartmentSearchRequest()
            {
                TypeOfResidentialBuildingId = idApartmentId
            });

            dgvApartments.DataSource = result;
        }

        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idCityObje = cmbCity.SelectedValue;
            if (int.TryParse(idCityObje.ToString(),out int id))
            {
                await LoadCities(id);
            }
        }
        private async Task LoadCities(int cityId)
        {
            var result = await _apartmentsService.Get<List<Model.ResidentialBuilding>>(new ApartmentSearchRequest()
            {
                CityId= cityId
            });
            dgvApartments.DataSource = result;
        }

        private void dgvApartments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvApartments.SelectedRows[0].Cells[0].Value;
            frmApartmentsAddNew frm = new frmApartmentsAddNew(int.Parse(id.ToString()));
            frm.Show();
            this.Close();
        }
    }
}
