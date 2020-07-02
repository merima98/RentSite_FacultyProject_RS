using RentSite.Model;
using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentSite.WinUI.Apartments
{
    public partial class frmApartmentsAddNew : Form
    {
        private readonly APIService _apartmentsService = new APIService("Apartments");
        private readonly APIService _lineOfTransportService = new APIService("LineOfTransport");
        private readonly APIService _cityServiceService = new APIService("City");
        private readonly APIService _typeOfApartmentsService = new APIService("TypeOfResidentialBuilding");
        private readonly APIService _lineOfTransportResidentialBuilding = new APIService("LineOfTransportResidentialBuilding");

        private int? _apartmentID = null;
        public frmApartmentsAddNew(int? apartment = null)
        {
            InitializeComponent();
            _apartmentID = apartment;
        }

        private async void frmApartmentsAddNew_Load(object sender, EventArgs e)
        {
            await LoadCity();
            await LoadTypeOfApartment();

            var typeOfLineTransport = await _lineOfTransportService.Get<IList<Model.LineOfTransport>>(null);

            clbLineOfTransport.DataSource = typeOfLineTransport;
            clbLineOfTransport.DisplayMember = "Name";

            if (_apartmentID.HasValue)
            {
                var apartment = await _apartmentsService.GetById<Model.ResidentialBuilding>(_apartmentID);
                txtAddress.Text = apartment.Address;
                txtArea.Text = apartment.Area;
                txtDescription.Text = apartment.Description;
                numFloorOne.Value = Convert.ToInt32(apartment.Floor);
                numFloors.Value = Convert.ToInt32(apartment.NubmerOfFloors);
                numRooms.Value = Convert.ToInt32(apartment.NumberOfRooms);
                numPrice.Value= Convert.ToDecimal(apartment.Price);
                txtTypeOfHeating.Text = apartment.TypeOfHeating;
                cbRented.Checked = apartment.Rented.Value;
            }
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

        ApartmentsInsertRequest request = new ApartmentsInsertRequest();

        private async void btnSaveApartment_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var lineOfTransportList = clbLineOfTransport.CheckedItems.Cast<LineOfTransport>();
                var lineOfTransportListId = lineOfTransportList.Select(x => x.Id).ToList();
                if (_apartmentID == null) //insert
                {
                    var idCityId = cmbCity.SelectedValue;

                    if (int.TryParse(idCityId.ToString(), out int idCity))
                    {
                        request.CityId = idCity;
                    }

                    var typeOfApartment = cmbTypeOfApartment.SelectedValue;
                    if (int.TryParse(typeOfApartment.ToString(), out int idTypeOfApartment))
                    {
                        request.TypeOfResidentialBuildingId = idTypeOfApartment;
                    }
                    request.LineOfTransport = lineOfTransportListId;
                    request.DateOfPublication = DateTime.Now; 
                    request.Description = txtDescription.Text;
                    request.Address = txtAddress.Text;
                    request.Area = txtArea.Text;
                    request.ArmoredDoor = cbArmoredDoor.Checked;
                    request.DateOfRenewal = dtpDateOfRenewal.Value;
                    
                    request.NubmerOfFloors = Convert.ToInt32(numFloors.Text);

                    request.Price = Convert.ToDecimal(numPrice.Text);
                    request.NumberOfRooms = Convert.ToInt32(numRooms.Text);
                    request.Floor = Convert.ToInt32(numFloorOne.Text);
                    request.TypeOfHeating = txtTypeOfHeating.Text;
                    request.Rented = cbRented.Checked;
                    request.NewlyBuilt = cbNewlyBuilt.Checked;

                    var apartment = await _apartmentsService.Insert<Model.ResidentialBuilding>(request);
                }
                else //update
                {
                    var idCityId = cmbCity.SelectedValue;

                    if (int.TryParse(idCityId.ToString(), out int idCity))
                    {
                        request.CityId = idCity;
                    }

                    var typeOfApartment = cmbTypeOfApartment.SelectedValue;
                    if (int.TryParse(typeOfApartment.ToString(), out int idTypeOfApartment))
                    {
                        request.TypeOfResidentialBuildingId = idTypeOfApartment;
                    }
                    request.LineOfTransport = lineOfTransportListId;
                    request.DateOfPublication = DateTime.Now; 
                    request.Description = txtDescription.Text;
                    request.Address = txtAddress.Text;
                    request.Area = txtArea.Text;
                    request.ArmoredDoor = cbArmoredDoor.Checked;
                    request.DateOfRenewal = dtpDateOfRenewal.Value;
                    request.Price = Convert.ToDecimal(numPrice.Text);
                    request.NubmerOfFloors = Convert.ToInt32(numFloors.Text);
                    request.NumberOfRooms = Convert.ToInt32(numRooms.Text);
                    request.Floor = Convert.ToInt32(numFloorOne.Text);
                    request.TypeOfHeating = txtTypeOfHeating.Text;
                    request.Rented = cbRented.Checked;
                    request.NewlyBuilt = cbNewlyBuilt.Checked;


                    var apartment = _apartmentsService.Update<Model.ResidentialBuilding>(_apartmentID, request);
                }
                MessageBox.Show("Operation successfully performed!");
                this.Close(); 
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
           var result= openFileDialog1.ShowDialog();
            if (result==DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Picture = file;
                txtPicture.Text = fileName;

                Image image = Image.FromFile(fileName);
                image = Resize(image, 50, 50);
                picAddApartment.Image = image;
            }
        }
        private Image Resize(Image img, int iWidth, int iHeight) 
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);

            return (Image)bmp;
        }
        private async void btnDeleteApartment_Click(object sender, EventArgs e)
        {
            if (_apartmentID != null) 
            {
                await _apartmentsService.Delete<Model.ResidentialBuilding>(_apartmentID);
                MessageBox.Show("Operation successfully performed!");
                this.Close();
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider.SetError(txtDescription, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDescription, null);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAddress, null);
            }
        }
     
        private void txtArea_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArea.Text))
            {
                errorProvider.SetError(txtArea, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtArea, null);
            }
        }

        private void cmbCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCity.Text))
            {
                errorProvider.SetError(cmbCity, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbCity, null);
            }
        }

        private void cmbTypeOfApartment_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbTypeOfApartment.Text))
            {
                errorProvider.SetError(cmbTypeOfApartment, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbTypeOfApartment, null);
            }
        }

        private void txtTypeOfHeating_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeOfHeating.Text))
            {
                errorProvider.SetError(txtTypeOfHeating, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTypeOfHeating, null);
            }
        }
        private void txtPicture_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPicture.Text))
            {
                errorProvider.SetError(txtPicture, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPicture, null);
            }
        }
        private void numFloors_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numFloors.Value.ToString()))
            {
                errorProvider.SetError(numFloors, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numFloors, null);
            }
        }
        private void numRooms_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numRooms.Value.ToString()))
            {
                errorProvider.SetError(numRooms, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numRooms, null);
            }
        }

        private void numFloorOne_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numFloorOne.Value.ToString()))
            {
                errorProvider.SetError(numFloorOne, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numFloorOne, null);
            }
        }
        private void numPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numPrice.Value.ToString()))
            {
                errorProvider.SetError(numPrice, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numPrice, null);
            }
        }
    }
}
